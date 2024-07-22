using BonEngineSharp.Framework;

namespace DoomTutorial;

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

public class Sector(
    int Id,
    List<Wall> Walls,
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
    public List<Wall> Walls { get; } = Walls;
    public int NumberOfWalls => Walls.Count; public int Height { get; } = Height;
    public int Elevation { get; } = Elevation;
    public float DistanceToPlayer { get; set; } = DistanceToPlayer;
    public uint WallColor { get; } = WallColor;
    public uint FloorColor { get; } = FloorColor;
    public uint CeilingColor { get; } = CeilingColor;
    public PlaneLookUpTable PortalsFloorXYLookUpTable { get; } = PortalsFloorXYLookUpTable;
    public PlaneLookUpTable PortalsCeilingXYLookUpTable { get; } = PortalsCeilingXYLookUpTable;
    public PlaneLookUpTable FloorXYLookUpTable { get; } = FloorXYLookUpTable;
    public PlaneLookUpTable CeilingXYLookUpTable { get; } = CeilingXYLookUpTable;
}
