namespace Bubbles.Gameplay;

public struct BubbleSimulationSystem : ISystem
{
    private const float MinInteractionDistanceSqr = 1e-8f;

    public void Update()
    {
        SimulationConfig config = GameW.GetResource<SimulationConfig>();

        GameW.Query<All<BubblePosition, BubbleVelocity>, None<BubbleForce>>().BatchAdd<BubbleForce>();

        AccumulateForces(config);
        
        // Vector3 nextVelocity = velocity.Value * s.DampingFactor + force.Value * s.DeltaTime;
    }

    private static void AccumulateForces(in SimulationConfig config)
    {
        float radius = config.SmoothingRadius;
        float radiusSqr = radius * radius;

        foreach (var self in GameW.Query<All<BubblePosition, BubbleVelocity, BubbleForce>>().Entities())
        {
            Vector3 position = self.Read<BubblePosition>().Value;
            Vector3 velocity = self.Read<BubbleVelocity>().Value;

            Vector3 force = BoundaryForce(position, config);

            foreach (var other in GameW.Query<All<BubblePosition, BubbleVelocity, BubbleForce>>().Entities())
            {
                Vector3 offset = position - other.Read<BubblePosition>().Value;
                float distanceSqr = offset.sqrMagnitude;
                if (distanceSqr >= radiusSqr || distanceSqr < MinInteractionDistanceSqr)
                    continue;

                float distance = Mathf.Sqrt(distanceSqr);
                Vector3 direction = offset / distance;
                float influence = 1f - distance / radius;

                force += direction * (influence * influence * config.PressureMultiplier);

                Vector3 relativeVelocity = other.Read<BubbleVelocity>().Value - velocity;
                force += relativeVelocity * (influence * config.ViscosityStrength);
            }

            self.Ref<BubbleForce>().Value = force;
        }
    }

    private static Vector3 BoundaryForce(Vector3 position, in SimulationConfig config)
    {
        float distanceFromCentre = position.magnitude;
        if (distanceFromCentre <= config.BoundsRadius)
            return Vector3.zero;

        float overshoot = distanceFromCentre - config.BoundsRadius;
        Vector3 inward = -position / distanceFromCentre;
        return inward * (overshoot * config.BoundaryStiffness);
    }
}