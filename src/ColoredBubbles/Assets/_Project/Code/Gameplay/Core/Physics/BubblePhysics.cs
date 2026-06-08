namespace Bubbles.Gameplay;

public static class BubblePhysics
{
    private struct BubbleHit
    {
        public Ray Ray;
        public float Distance;
        public GameW.Entity Target;
        public bool Found;
    }

    public static bool Raycast(Ray ray, out EntityGID bubble)
    {
        BubbleHit bubbleHit = new BubbleHit
        {
            Ray = ray,
            Distance = float.PositiveInfinity,
        };

        GameW.Query().For(ref bubbleHit, static (
            ref BubbleHit hit,
            GameW.Entity entity,
            in BubblePosition position,
            in BubbleRadius radius
        ) =>
        {
            Vector3 originToCenter = position.Value - hit.Ray.origin;
            float projectionLength = Vector3.Dot(originToCenter, hit.Ray.direction);
            float perpendicularSquared =
                Vector3.Dot(originToCenter, originToCenter) - projectionLength * projectionLength;

            float radiusSquared = radius.Value * radius.Value;
            if (perpendicularSquared > radiusSquared)
                return;

            float halfChord = Mathf.Sqrt(radiusSquared - perpendicularSquared);
            float nearDistance = projectionLength - halfChord;
            float farDistance = projectionLength + halfChord;

            float hitDistance = nearDistance >= 0f ? nearDistance : farDistance;
            if (hitDistance < 0f)
                return;

            if (hitDistance < hit.Distance)
            {
                hit.Distance = hitDistance;
                hit.Target = entity;
                hit.Found = true;
            }
        });

        if (bubbleHit.Found)
        {
            bubble = bubbleHit.Target.GID;
            return true;
        }
        else
        {
            bubble = default;
            return false;
        }
    }
}