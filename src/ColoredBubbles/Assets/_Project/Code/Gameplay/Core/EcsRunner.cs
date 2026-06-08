namespace Bubbles.Gameplay;

public sealed class EcsRunner : MonoBehaviour
{
    public void Start()
    {
        GameW.Create(WorldConfig.Default());

        InputSys.Create();
        GameplaySys.Create();
        PhysicsSys.Create();
        RenderSys.Create();

        GameW.Types().RegisterAll(typeof(EcsRunner).Assembly);
        UnityEventTypes.Register<GameWT>();

        EcsDebug<GameWT>.AddWorld<GameplayST>();

        RegisterInputSystems();
        RegisterGameplaySystems();
        RegisterPhysicsSystems();
        RegisterRenderSystems();

        GameW.Initialize();

        InputSys.Initialize();
        GameplaySys.Initialize();
        PhysicsSys.Initialize();
        RenderSys.Initialize();
    }

    private void Update()
    {
        InputSys.Update();
        GameplaySys.Update();
    }

    private void FixedUpdate()
    {
        PhysicsSys.Update();
    }

    private void LateUpdate()
    {
        RenderSys.Update();
        GameW.Tick();
    }

    private void OnDestroy()
    {
        InputSys.Destroy();
        GameplaySys.Destroy();
        PhysicsSys.Destroy();
        RenderSys.Destroy();

        GameW.Destroy();
    }

    private static void RegisterInputSystems()
    {
        InputSys.Add(new InitializePlayerInputMapInputSys(), short.MinValue);
        InputSys.Add(new DisposePlayerInputMapInputSys(), short.MaxValue);

        InputSys.Add(new RegisterInputActionEvents());

        InputSys.Add(new EmitRotationDeltaSystem());
        
        InputSys.Add(new RaiseRaycastEventSystem());
    }

    private static void RegisterGameplaySystems()
    {
        GameplaySys.Add(new RotateCameraSystem());
        GameplaySys.Add(new PositionCameraSystem());
    }

    private static void RegisterPhysicsSystems()
    {
        PhysicsSys.Add(new HandleRaycastSystem());
    }

    private static void RegisterRenderSystems()
    {
        RenderSys.Add(new SynchronizeCameraTransformSystem(), short.MaxValue);
    }
}