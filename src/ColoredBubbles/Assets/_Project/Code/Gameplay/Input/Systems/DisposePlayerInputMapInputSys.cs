namespace Bubbles.Gameplay;

public struct DisposePlayerInputMapInputSys : ISystem
{
    public void Destroy()
    {
        GameW.GetResource<PlayerInputMap>().Value.Disable();
        GameW.GetResource<PlayerInputMap>().Value.Dispose();
    }
}