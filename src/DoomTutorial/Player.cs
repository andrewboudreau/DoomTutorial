using BonEngineSharp.Framework;

namespace DoomTutorial;

public struct Player(PointF position, float z, float angle)
{
    public Player()
        : this(new(), 0, 0) { }

    public Player(float x, float y, float z, float Angle)
        : this(new(x, y), z, Angle) { }

    public PointF Position { get; set; } = position;
    public float Z { get; set; } = z;
    public float Angle { get; set; } = angle;
}
