namespace Bubbles.Gameplay;

public struct HandleRaycastSystem : ISystem
{
    private EventReceiver<GameWT, RaycastEvent> _raycastEventReceiver;

    public void Init()
    {
        _raycastEventReceiver = GameW.RegisterEventReceiver<RaycastEvent>();
    }

    public void Destroy()
    {
        GameW.DeleteEventReceiver(ref _raycastEventReceiver);
    }

    public void Update()
    {
        foreach (World<GameWT>.Event<RaycastEvent> raycastEvent in _raycastEventReceiver)
        {
            if (BubblePhysics.Raycast(raycastEvent.Value.Ray, out EntityGID bubbleHit))
            {
                GameW.SendEvent(new SelectBubbleEvent()
                {
                    Target = bubbleHit
                });
            }
        }
    }
}