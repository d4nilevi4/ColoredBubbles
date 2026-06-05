namespace Bubbles.Gameplay;

public struct InitializePlayerInputMapInputSys : ISystem
{
    public void Init()
    {
        GameW.SetResource<PlayerInputMap>(new PlayerInputMap()
        {
            Value = new PlayerInputActions()
        });
        GameW.GetResource<PlayerInputMap>().Value.Enable();
    }
}