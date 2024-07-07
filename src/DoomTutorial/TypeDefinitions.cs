using BonEngineSharp.Framework;

namespace DoomTutorial;

public struct Player(PointF Position, float Z, float Angle)
{
    public Player() : this(new(), 0, 0) { }

    public PointF Position { get; } = Position;
    public float Z { get; set; } = Z;
    public float Angle { get; set; } = Angle;
}


public readonly record struct Wall(
    PointI A,
    PointI B,
    float PortalTopHeight,
    float PortalBottomHeight,
    bool IsPortal);

public readonly record struct PlaneLookUpTable()
{
    public int[] T { get; } = new int[1024];
    public int[] B { get; } = new int[1024];
};

public readonly struct Sector(
    int Id,
    Wall[] Walls,
    int NumberOfWalls,
    int Height,
    int Elevation,
    float DistanceToPlayer,
    uint WallColor,
    uint FloorColor,
    uint CeilingColor,
    PlaneLookUpTable PortalsFloorXYLookUpTable,
    PlaneLookUpTable PortalsCeilingXYLookUpTable,
    PlaneLookUpTable FloorXYLookUpTable,
    PlaneLookUpTable CeilingXYLookUpTable)
{
    public int Id { get; } = Id;
    public Wall[] Walls { get; } = Walls;
    public int NumberOfWalls { get; } = NumberOfWalls;
    public int Height { get; } = Height;
    public int Elevation { get; } = Elevation;
    public float DistanceToPlayer { get; } = DistanceToPlayer;
    public uint WallColor { get; } = WallColor;
    public uint FloorColor { get; } = FloorColor;
    public uint CeilingColor { get; } = CeilingColor;
    public PlaneLookUpTable PortalsFloorXYLookUpTable { get; } = PortalsFloorXYLookUpTable;
    public PlaneLookUpTable PortalsCeilingXYLookUpTable { get; } = PortalsCeilingXYLookUpTable;
    public PlaneLookUpTable FloorXYLookUpTable { get; } = FloorXYLookUpTable;
    public PlaneLookUpTable CeilingXYLookUpTable { get; } = CeilingXYLookUpTable;
}

public struct SectorQueue()
{
    Sector[] Sectors { get; } = new Sector[1024];
    int NumberOfSectors { get; set; } = 0;
}