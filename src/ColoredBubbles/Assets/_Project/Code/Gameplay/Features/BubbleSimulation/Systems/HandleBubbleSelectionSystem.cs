namespace Bubbles.Gameplay;

public struct HandleBubbleSelectionSystem : ISystem
{
    private static All<BubbleColor> _bubbleColorFilter = default;
    
    private EventReceiver<GameWT, SelectBubbleEvent> _selectBubbleReceiver;

    public void Init()
    {
        _selectBubbleReceiver = GameW.RegisterEventReceiver<SelectBubbleEvent>();
    }

    public void Destroy()
    {
        GameW.DeleteEventReceiver(ref _selectBubbleReceiver);
    }

    public void Update()
    {
        foreach (var selectBubbleEvent in _selectBubbleReceiver)
        {
            if (!selectBubbleEvent.Value.Target.TryUnpack<GameWT>(out var target))
                return;
            
            if(!target.IsMatch(_bubbleColorFilter))
                return;
            
            if (TryGetSelectedBubble(out var selectedBubble))
            {
                if (selectedBubble == target)
                    selectedBubble.Delete<BubbleSelected>();
                else
                {
                    if (selectedBubble.Read<BubbleColor>().Value == target.Read<BubbleColor>().Value)
                    {
                        selectedBubble.Delete<BubbleSelected>();
                        
                        selectedBubble.Set(new GameW.Link<MatchTarget>(target));
                        target.Set(new GameW.Link<MatchTarget>(selectedBubble));
                    }
                }
            }
            else
            {
                target.Set<BubbleSelected>();
            }
        }
    }

    private static bool TryGetSelectedBubble(out World<GameWT>.Entity selectedBubble)
    {
        if (GameW.Query<All<BubbleSelected, BubbleColor>>().One(out selectedBubble))
        {
            return true;
        }

        return false;
    }
}