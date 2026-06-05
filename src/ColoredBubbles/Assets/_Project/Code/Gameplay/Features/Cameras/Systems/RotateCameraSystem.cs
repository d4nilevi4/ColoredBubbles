namespace Bubbles.Gameplay;

public struct RotateCameraSystem : ISystem
{
    public void Update()
    {
        GameW.Query().For(static
        (
            ref CameraRotation cameraRotation,
            in CameraRotationDelta rotationDelta,
            in CameraRotationSpeed rotationSpeed
        ) =>
        {
            if (rotationDelta.Value.sqrMagnitude > 0f)
            {
                Quaternion yawDelta = Quaternion.AngleAxis(rotationDelta.Value.x * rotationSpeed.Value.x, Vector3.up);
                Quaternion pitchDelta =
                    Quaternion.AngleAxis(-rotationDelta.Value.y * rotationSpeed.Value.y, Vector3.right);
                cameraRotation.Value = cameraRotation.Value * yawDelta * pitchDelta;
            }
        });
    }
}