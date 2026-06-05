namespace Bubbles.Gameplay;

public struct SynchronizeCameraTransformSystem : ISystem
{
    public void Update()
    {
        GameW.Query<All<MainCamera>>().For(static (
            ref UnityCamera camera,
            in CameraPosition position,
            in CameraRotation rotation
        ) =>
        {
            camera.Value.transform.position = position.Value;
            camera.Value.transform.rotation = rotation.Value;
        });
    }
}