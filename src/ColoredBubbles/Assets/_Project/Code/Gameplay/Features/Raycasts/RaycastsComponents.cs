namespace Bubbles.Gameplay;

[Serializable] 
public struct RaycastEvent : IEvent
{
    public Ray Ray;
}