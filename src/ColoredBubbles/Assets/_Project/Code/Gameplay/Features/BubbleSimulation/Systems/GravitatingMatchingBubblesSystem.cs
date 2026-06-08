namespace Bubbles.Gameplay;

public struct GravitatingMatchingBubblesSystem : ISystem
{
    private static All<BubblePosition, BubbleVelocity> BubbleFilter;

    public void Update()
    {
        GameW.Query().For(static (
            ref BubbleVelocity velocity,
            in BubblePosition position,
            in GameW.Link<MatchTarget> matchTarget
        ) =>
        {
            if (!matchTarget.Value.TryUnpack<GameWT>(out var target))
                return;

            if (!target.IsMatch(BubbleFilter))
                return;

            Vector3 direction = (target.Read<BubblePosition>().Value - position.Value).normalized;

            var burstingSpeed = GameW.GetResource<SimulationConfig>().BurstingAcceleration * Time.deltaTime;
            velocity.Value += direction * burstingSpeed;
        });
    }
}