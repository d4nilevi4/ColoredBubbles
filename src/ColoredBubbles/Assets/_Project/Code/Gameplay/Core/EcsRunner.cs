namespace Bubbles.Gameplay;

public sealed class EcsRunner : MonoBehaviour
{
    public void Start()
    {
        GameW.Create(WorldConfig.Default());

        InputSys.Create();
        UpdateSys.Create();
        PhysicsSys.Create();

        GameW.Types().RegisterAll(typeof(EcsRunner).Assembly);
        UnityEventTypes.Register<GameWT>();

        EcsDebug<GameWT>.AddWorld<UpdateST>();

        // InputSys
            // .Add(new System(), 0)
            // ;

        // UpdateSys
            // .Add(new System(), 0)
            // ;
            
        // PhysicsSys
            // .Add(new System(), 0)
            // ;     

        GameW.Initialize();

        InputSys.Initialize();
        UpdateSys.Initialize();
        PhysicsSys.Initialize();
    }

    private void Update()
    {
        InputSys.Update();
        UpdateSys.Update();
        GameW.Tick();
    }

    private void FixedUpdate()
    {
        PhysicsSys.Update();
    }

    private void OnDestroy()
    {
        InputSys.Destroy();
        UpdateSys.Destroy();
        PhysicsSys.Destroy();

        GameW.Destroy();
    }
}