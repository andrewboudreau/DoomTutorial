using BonEngineSharp;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

using DoomTutorial;

class DoomScene : Scene
{
    public const float MoveSpeed = 150.0f;
    public const float ElevationSpeed = 50_000.0f;
    public const float RotationSpeed = 4.0f;

    private Player player;

    public override string SceneName => "Doom Tutorial";

    protected override void FixedUpdate(double deltaTime)
    {
        var fDeltaTime = (float)deltaTime;

        if (Input.Down(KeyCodes.KeyW))
        {
            player.Position.Add(
                MoveSpeed * MathF.Cos(player.Angle) * fDeltaTime,
                MoveSpeed * MathF.Sin(player.Angle) * fDeltaTime);
        }
        else if (Input.Down(KeyCodes.KeyS))
        {
            player.Position.Substract(
                MoveSpeed * MathF.Sin(player.Angle) * fDeltaTime,
                MoveSpeed * MathF.Cos(player.Angle) * fDeltaTime);
        }

        if (Input.Down(KeyCodes.KeyQ))
        {
            player.Angle += RotationSpeed * fDeltaTime;
        }
        else if (Input.Down(KeyCodes.KeyE))
        {
            player.Angle -= RotationSpeed * fDeltaTime;
        }

        if (Input.Down(KeyCodes.KeyD))
        {
            player.Position.Add(
                MoveSpeed * MathF.Cos(player.Angle + MathF.PI / 2) * fDeltaTime,
                MoveSpeed * MathF.Sin(player.Angle + MathF.PI / 2) * fDeltaTime);
        }
        else if (Input.Down(KeyCodes.KeyA))
        {
            player.Position.Add(
                MoveSpeed * MathF.Sin(player.Angle + MathF.PI / 2) * fDeltaTime,
                MoveSpeed * MathF.Cos(player.Angle + MathF.PI / 2) * fDeltaTime);
        }

        if (Input.Down(KeyCodes.KeyZ))
        {
            player.Z += ElevationSpeed * fDeltaTime;
        }
        else if (Input.Down(KeyCodes.KeyX))
        {
            player.Z -= ElevationSpeed * fDeltaTime;
        }
    }

    protected override void Update(double deltaTime)
    {
    }

    // called every frame to draw scene
    protected override void Draw()
    {
        Gfx.DrawRectangle(new RectangleI(50, 50, 25, 25), Color.Red, true);
    }

    // called when scene loads
    protected override void Load()
    {
        player = new();
    }

    // called when scene unloads
    protected override void Unload()
    {
    }

    public void Render(Player player, GameState gameState)
    {

    }

    public void DrawWalls(Player player, GameState gameState)
    {

    }

    public Sector CreateSector(int height, int elevation, uint color, uint ceilingColor, uint floorColor)
    {
        return new Sector(0, new Wall[0], 0, height, elevation, 0, color, floorColor, ceilingColor, new PlaneLookUpTable(), new PlaneLookUpTable(), new PlaneLookUpTable(), new PlaneLookUpTable());
    }

    public void AddWallToSector(Sector sector, Wall vertices)
    {

    }

    public void AddSectorToQueue(SectorQueue queue, Sector sector)
    {
    }

    public Wall CreateWall(int ax, int ay, int bx, int by)
    {
        return new Wall(new PointF(ax, ay), new PointF(bx, by), 0, 0, false);
    }

    public Wall CreatePortal(int ax, int ay, int bx, int by, int th, int bh)
    {

        return new Wall(new PointF(ax, ay), new PointF(bx, by), th, bh, true);
    }
}
