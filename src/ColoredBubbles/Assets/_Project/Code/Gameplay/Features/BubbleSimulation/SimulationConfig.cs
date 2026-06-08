namespace Bubbles.Gameplay;

[Serializable]
public struct SimulationConfig : IResource
{
    public float SmoothingRadius;
    public float PressureMultiplier;
    public float ViscosityStrength;
    public float BoundsRadius;
    public float BoundaryStiffness;
    public float Damping;
    public float MaxSpeed;

    // Sensible starting values; tune to taste.
    public static SimulationConfig Default() => new()
    {
        SmoothingRadius = 1.5f,
        PressureMultiplier = 40f,
        ViscosityStrength = 4f,
        BoundsRadius = 8f,
        BoundaryStiffness = 60f,
        Damping = 1.5f,
        MaxSpeed = 12f,
    };
}