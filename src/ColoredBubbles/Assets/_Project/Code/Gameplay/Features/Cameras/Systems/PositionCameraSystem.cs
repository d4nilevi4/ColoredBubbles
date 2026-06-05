namespace Bubbles.Gameplay;

public struct PositionCameraSystem : ISystem
{
    public void Update()
    {
        GameW.Query().For(static
        (
            ref CameraPosition cameraPosition,
            in CameraRotation cameraRotation,
            in CameraDistance cameraDistance,
            in CameraPivot cameraPivot
        ) =>
        {
           
            Vector3 offset = cameraRotation.Value * new Vector3(0f, 0f, -cameraDistance.Value);
            cameraPosition.Value = cameraPivot.Value + offset;
        });
    }
}