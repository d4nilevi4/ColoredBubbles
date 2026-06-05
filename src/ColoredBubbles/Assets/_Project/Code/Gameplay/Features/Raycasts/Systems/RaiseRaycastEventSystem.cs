namespace Bubbles.Gameplay;

public struct RaiseRaycastEventSystem : ISystem
{
    private EventReceiver<GameWT, InteractionEvent> _interactionEventReceiver;

    public void Init()
    {
        _interactionEventReceiver = GameW.RegisterEventReceiver<InteractionEvent>();
    }

    public void Destroy()
    {
        GameW.DeleteEventReceiver(ref _interactionEventReceiver);
    }

    public void Update()
    {
        foreach (World<GameWT>.Event<InteractionEvent> interactionEvent in _interactionEventReceiver)
        {
            if(!GameW.Query<All<MainCamera, UnityCamera>>().One(out World<GameWT>.Entity cameraEntity))
                continue;

            Camera camera = cameraEntity.Read<UnityCamera>().Value;
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            
            GameW.SendEvent(new RaycastEvent()
            {
                Origin = ray.origin,
                Direction = ray.direction.normalized
            });
        }
    }
}