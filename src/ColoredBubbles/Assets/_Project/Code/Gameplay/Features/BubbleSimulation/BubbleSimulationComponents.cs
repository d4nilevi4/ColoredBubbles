namespace Bubbles.Gameplay;

[Serializable] public struct BubblePosition : IComponent { public Vector3 Value; }
[Serializable] public struct BubbleVelocity : IComponent { public Vector3 Value; }
[Serializable] public struct BubbleRadius : IComponent { public float Value; }
[Serializable] public struct BubbleColor : IComponent { public Color Value; }

[Serializable] public struct BubbleForce : IComponent { public Vector3 Value; }
[Serializable] public struct MatchTarget : ILinkType { }

[Serializable] public struct BubbleSelected : ITag { }

[Serializable]
public struct SelectBubbleEvent : IEvent
{
    public EntityGID Target;
}