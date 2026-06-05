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

        InputSys
            .Add(new InitializePlayerInputMapInputSys(), short.MinValue)
            .Add(new DisposePlayerInputMapInputSys(), short.MaxValue)
            
            .Add(new RegisterInputActionEvents())
            
            .Add(new EmitRotationDeltaSystem())
            ;

        // GameplaySys
            // .Add(new System(), 0)
            // ;
            
        // PhysicsSys
            // .Add(new System(), 0)
            // ;     

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
        RenderSys.Update();
        GameW.Tick();
    }

    private void FixedUpdate()
    {
        PhysicsSys.Update();
    }

    private void OnDestroy()
    {
        InputSys.Destroy();
        GameplaySys.Destroy();
        PhysicsSys.Destroy();
        RenderSys.Destroy();

        GameW.Destroy();
    }
}