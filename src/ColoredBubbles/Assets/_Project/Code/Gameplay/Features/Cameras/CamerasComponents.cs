namespace Bubbles.Gameplay;

[Serializable] public struct MainCamera : ITag { }
[Serializable] public struct UnityCamera : IComponent { public Camera Value; }
[Serializable] public struct CameraRotationSpeed : IComponent { public Vector2 Value; }
[Serializable] public struct CameraRotation : IComponent { public Quaternion Value; }
[Serializable] public struct CameraPosition : IComponent { public Vector3 Value; }
[Serializable] public struct CameraDistance : IComponent { public float Value; }
[Serializable] public struct CameraPivot : IComponent { public Vector3 Value; }