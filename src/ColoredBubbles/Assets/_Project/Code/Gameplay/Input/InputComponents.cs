namespace Bubbles.Gameplay;

[Serializable]
public struct PlayerInputMap : IResource { public PlayerInputActions Value; }

[Serializable]
public struct CameraRotationDelta : IComponent { public Vector2 Value; }

[Serializable]
public struct InteractionEvent : IEvent {}