namespace Bubbles.Gameplay;

public struct CollapseBubbleSystem : ISystem
{
    private static readonly All<BubblePosition> BubbleFilter;
    
    public void Update()
    {
        GameW.Query().For(static (
            GameW.Entity entity,
            in BubblePosition bubblePosition,
            in GameW.Link<MatchTarget> matchTarget
        ) =>
        {
            if (!matchTarget.Value.TryUnpack<GameWT>(out var target) || !target.IsMatch(BubbleFilter))
                return;

            if ((bubblePosition.Value - target.Read<BubblePosition>().Value).sqrMagnitude < 0.01f)
            {
                GameW.SendEvent(new CollapseBubblesEvent());
                
                entity.Delete<GameW.Link<MatchTarget>>();
                target.Delete<GameW.Link<MatchTarget>>(); // Exception?? 
            }
        });
    }
}