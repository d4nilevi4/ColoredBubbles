namespace Bubbles.Gameplay;

[Serializable] 
public struct RaycastEvent : IEvent
{
    public Vector3 Origin;
    public Vector3 Direction;
}