namespace Bubbles.Gameplay;

[Serializable]
public class SimulationConfig : IResource
{
    public float SmoothingRadius;
    public float PressureMultiplier;
    public float ViscosityStrength;
    public float BoundsRadius;
    public float BoundaryStiffness;
    public float Damping;
    public float MaxSpeed;
    public float BurstingAcceleration;
}