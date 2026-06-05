namespace Bubbles.Gameplay;

[Serializable]
public struct PlayerInputMap : IResource { public PlayerInputActions Value; }

[Serializable]
public struct RotationDelta : IComponent { public Vector2 Value; }

[Serializable]
public struct InteractionEvent : IEvent {}