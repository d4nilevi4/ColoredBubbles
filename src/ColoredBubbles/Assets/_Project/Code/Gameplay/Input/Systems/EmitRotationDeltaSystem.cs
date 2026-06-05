namespace Bubbles.Gameplay;

public struct EmitRotationDeltaSystem : ISystem
{
    public void Update()
    {
        GameW.Query().For(static (ref CameraRotationDelta input) =>
        {
            input.Value = GameW.GetResource<PlayerInputMap>().Value.Gameplay.RotateCamera.ReadValue<Vector2>();
        });
    }
}