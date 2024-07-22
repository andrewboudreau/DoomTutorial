using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;
using BonEngineSharp.Managers;

using DoomTutorial;

public struct Quad
{
    public int ax, bx;
    public int at, ab;
    public int bt, bb;
}

class DoomScene : Scene
{
    const int IS_WALL = 0;
    const int IS_CEIL = 1;
    const int IS_FLOOR = 2;

    public const float MoveSpeed = 150.0f;
    public const float ElevationSpeed = 50_000.0f;
    public const float RotationSpeed = 4.0f;

    public const int ScreenWidth = 1024;
    public const int ScreenHeight = 768;
    public const int TargetFrameRate = 120;

    private GameState gameState;
    private Player player;

    private List<Sector> sectorQueue = new(50);

    public override string SceneName => "Doom Tutorial";

    //
    //called when scene loads
    protected override void Load()
    {
        Gfx.SetWindowProperties("Doom Tutorial", ScreenWidth, ScreenHeight, WindowModes.Windowed, false);

        gameState = new(ScreenWidth, ScreenHeight, TargetFrameRate);
        gameState.IsDebugMode = true;
        player = new(40, 40, ScreenHeight * 10, MathF.PI / 2);

        Sector s1 = R_CreateSector(10, 0, 0xd6382d, 0xf54236, 0x9c2921);
        Sector s2 = R_CreateSector(20, 0, 0xd6382d, 0xf54236, 0x9c2921);
        Sector s3 = R_CreateSector(30, 0, 0xd6382d, 0xf54236, 0x9c2921);
        Sector s4 = R_CreateSector(40, 0, 0xd6382d, 0xf54236, 0x9c2921);

        Sector s5 = R_CreateSector(80, 0, 0x29ba48, 0x43f068, 0x209138);
        Sector s6 = R_CreateSector(80, 0, 0x29ba48, 0x43f068, 0x209138);
        Sector s7 = R_CreateSector(80, 0, 0x29ba48, 0x43f068, 0x209138);

        Sector s8 = R_CreateSector(80, 0, 0x29ba48, 0xd43f068, 0x209138);
        Sector s9 = R_CreateSector(80, 0, 0x29ba48, 0xd43f068, 0x209138);
        Sector s10 = R_CreateSector(80, 0, 0x29ba48, 0xd43f068, 0x209138);

        Sector s11 = R_CreateSector(30, 0, 0xa3a24b, 0xd9d764, 0x858338);
        Sector s12 = R_CreateSector(30, 0, 0xa3a24b, 0xd9d764, 0x858338);

        Sector s13 = R_CreateSector(10, 0, 0xa3a24b, 0xd9d764, 0x858338);
        Sector s14 = R_CreateSector(10, 0, 0xa3a24b, 0xd9d764, 0x858338);
        Sector s15 = R_CreateSector(30, 10, 0xa3a24b, 0xd9d764, 0x858338);
        Sector s16 = R_CreateSector(30, 10, 0xa3a24b, 0xd9d764, 0x858338);

        int[] s1v = [
            70,  220, 100, 220,
            100, 220, 100, 240,
            100, 240, 70,  240,
            70,  240, 70,  220
        ];

        int[] s2v = [
            70, 200, 100, 200,
            100, 200, 100, 220,
            100, 220, 70, 220,
            70, 220, 70, 200
        ];

        int[] s3v = [
            70, 180, 100, 180,
            100, 180, 100, 200,
            100, 200, 70, 200,
            70, 200, 70, 180
        ];

        int[] s4v = [
            70, 120, 100, 120,
            100, 120, 110, 140,
            110, 140, 110, 160,
            110, 160, 100, 180,
            100, 180, 70, 180,
            70, 180, 60, 160,
            60, 160, 60, 140,
            60, 140, 70, 120
        ];

        int[] s5v = [
            30, 190, 40, 190,
            40, 190, 50, 200,
            50, 200, 50, 220,
            50, 220, 30, 190
        ];

        int[] s6v = [
            30, 120, 40, 120,
            40, 120, 40, 190,
            40, 190, 30, 190,
            30, 190, 30, 120
        ];

        int[] s7v = [
            60, 70, 60, 90,
            60, 90, 40, 120,
            40, 120, 30, 120,
            30, 120, 60, 70
        ];

        int[] s8v = [
            120, 200, 130, 190,
            130, 190, 140, 190,
            140, 190, 120, 220,
            120, 220, 120, 200
        ];

        int[] s9v = [
            130, 120, 140, 120,
            140, 120, 140, 190,
            140, 190, 130, 190,
            130, 190, 130, 120
        ];

        int[] s10v = [
            110, 70, 140, 120,
            140, 120, 130, 120,
            130, 120, 110, 90,
            110, 90, 110, 70
        ];

        int[] s11v = [
            30, 20, 50, 20,
            50, 20, 50, 50,
            50, 50, 30, 50,
            30, 50, 30, 20
        ];

        int[] s12v = [
            120, 20, 140, 20,
            140, 20, 140, 50,
            140, 50, 120, 50,
            120, 50, 120, 20
        ];

        int[] s13v = [
            30, 250, 60, 250,
            60, 250, 60, 300,
            60, 300, 30, 300,
            30, 300, 30, 250
        ];

        int[] s14v = [
            110, 250, 140, 250,
            140, 250, 140, 300,
            140, 300, 110, 300,
            110, 300, 110, 250
        ];

        int[] s15v = [
            40, 260, 50, 260,
            50, 260, 50, 290,
            50, 290, 40, 290,
            40, 290, 40, 260
        ];

        int[] s16v = [
            120, 260, 130, 260,
            130, 260, 130, 290,
            130, 290, 120, 290,
            120, 290, 120, 260
        ];

        for (int i = 0; i < 16; i += 4)
        {
            Wall w = R_CreateWall(s1v[i], s1v[i + 1], s1v[i + 2], s1v[i + 3]);
            R_SectorAddWall(s1, w);

            w = R_CreateWall(s2v[i], s2v[i + 1], s2v[i + 2], s2v[i + 3]);
            R_SectorAddWall(s2, w);

            w = R_CreateWall(s3v[i], s3v[i + 1], s3v[i + 2], s3v[i + 3]);
            R_SectorAddWall(s3, w);

            //----

            w = R_CreateWall(s5v[i], s5v[i + 1], s5v[i + 2], s5v[i + 3]);
            R_SectorAddWall(s5, w);
            w = R_CreatePortal(s6v[i], s6v[i + 1], s6v[i + 2], s6v[i + 3], 20, 10);
            R_SectorAddWall(s6, w);
            w = R_CreateWall(s7v[i], s7v[i + 1], s7v[i + 2], s7v[i + 3]);
            R_SectorAddWall(s7, w);

            w = R_CreateWall(s8v[i], s8v[i + 1], s8v[i + 2], s8v[i + 3]);
            R_SectorAddWall(s8, w);
            w = R_CreatePortal(s9v[i], s9v[i + 1], s9v[i + 2], s9v[i + 3], 20, 10);
            R_SectorAddWall(s9, w);
            w = R_CreateWall(s10v[i], s10v[i + 1], s10v[i + 2], s10v[i + 3]);
            R_SectorAddWall(s10, w);

            //---
            w = R_CreateWall(s11v[i], s11v[i + 1], s11v[i + 2], s11v[i + 3]);
            R_SectorAddWall(s11, w);
            w = R_CreateWall(s12v[i], s12v[i + 1], s12v[i + 2], s12v[i + 3]);
            R_SectorAddWall(s12, w);

            w = R_CreateWall(s13v[i], s13v[i + 1], s13v[i + 2], s13v[i + 3]);
            R_SectorAddWall(s13, w);
            w = R_CreateWall(s14v[i], s14v[i + 1], s14v[i + 2], s14v[i + 3]);
            R_SectorAddWall(s14, w);
            w = R_CreateWall(s15v[i], s15v[i + 1], s15v[i + 2], s15v[i + 3]);
            R_SectorAddWall(s15, w);
            w = R_CreateWall(s16v[i], s16v[i + 1], s16v[i + 2], s16v[i + 3]);
            R_SectorAddWall(s16, w);
        }

        for (int i = 0; i < 8 * 4; i += 4)
        {
            Wall w = R_CreateWall(s4v[i], s4v[i + 1], s4v[i + 2], s4v[i + 3]);
            R_SectorAddWall(s4, w);
        }

        R_AddSectorToQueue(s1);
        R_AddSectorToQueue(s2);
        R_AddSectorToQueue(s3);
        R_AddSectorToQueue(s4);
        R_AddSectorToQueue(s5);
        R_AddSectorToQueue(s6);
        R_AddSectorToQueue(s7);
        R_AddSectorToQueue(s8);
        R_AddSectorToQueue(s9);
        R_AddSectorToQueue(s10);
        R_AddSectorToQueue(s11);
        R_AddSectorToQueue(s12);
        R_AddSectorToQueue(s13);
        R_AddSectorToQueue(s14);
        R_AddSectorToQueue(s15);
        R_AddSectorToQueue(s16);
    }

    protected override void FixedUpdate(double deltaTime)
    {
        var fDeltaTime = (float)deltaTime;

        if (Input.Down(KeyCodes.KeyW))
        {
            player.Position = player.Position.AddSelf(
                MoveSpeed * MathF.Cos(player.Angle) * fDeltaTime,
                MoveSpeed * MathF.Sin(player.Angle) * fDeltaTime);
        }
        else if (Input.Down(KeyCodes.KeyS))
        {
            player.Position = player.Position.SubstractSelf(
                MoveSpeed * MathF.Cos(player.Angle) * fDeltaTime,
                MoveSpeed * MathF.Sin(player.Angle) * fDeltaTime);
        }

        if (Input.Down(KeyCodes.KeyQ))
        {
            player.Angle += RotationSpeed * fDeltaTime;
        }
        else if (Input.Down(KeyCodes.KeyE))
        {
            player.Angle -= RotationSpeed * fDeltaTime;
        }

        if (Input.Down(KeyCodes.KeyA))
        {
            player.Position = player.Position.AddSelf(
                MoveSpeed * MathF.Cos(player.Angle + MathF.PI / 2) * fDeltaTime,
                MoveSpeed * MathF.Sin(player.Angle + MathF.PI / 2) * fDeltaTime);
        }
        else if (Input.Down(KeyCodes.KeyD))
        {
            player.Position = player.Position.SubstractSelf(
                MoveSpeed * MathF.Cos(player.Angle + MathF.PI / 2) * fDeltaTime,
                MoveSpeed * MathF.Sin(player.Angle + MathF.PI / 2) * fDeltaTime);
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
        Gfx.ClearScreen(Color.Black);
        Gfx.DrawRectangle(new RectangleI(50, 50, 25, 25), Color.Red, true);
        RenderSectors(player, gameState);
    }

    private void RenderSectors(Player player, GameState gameState)
    {
        float screenHalfWidth = ScreenWidth / 2;
        float screenHalfHeight = ScreenHeight / 2;
        float fov = 300;

        R_SortSectorsByDistToPlayer(player.Position);

        // loop sectors
        for (int i = 0; i < sectorQueue.Count; i++)
        {
            Sector s = sectorQueue[i];

            int sector_h = s.Height;
            int sector_e = s.Elevation;
            uint sector_clr = s.WallColor;

            for (int j = 0; j < 1024; j++)
            {
                s.CeilingXYLookUpTable.T[j] = 0;
                s.CeilingXYLookUpTable.B[j] = 0;
                s.FloorXYLookUpTable.T[j] = 0;
                s.FloorXYLookUpTable.B[j] = 0;
                s.PortalsCeilingXYLookUpTable.T[j] = 0;
                s.PortalsCeilingXYLookUpTable.B[j] = 0;
                s.PortalsFloorXYLookUpTable.T[j] = 0;
                s.PortalsFloorXYLookUpTable.B[j] = 0;
            }

            //loop walls
            for (int k = 0; k < s.NumberOfWalls; k++)
            {
                var w = s.Walls[k];

                // displace the world based on player's position
                float dx1 = w.A.X - player.Position.X;
                float dy1 = w.A.Y - player.Position.Y;
                float dx2 = w.B.X - player.Position.X;
                float dy2 = w.B.Y - player.Position.Y;

                // rotate the world around the player
                float SN = MathF.Sin(player.Angle);
                float CN = MathF.Cos(player.Angle);
                float wx1 = dx1 * SN - dy1 * CN;
                float wz1 = dx1 * CN + dy1 * SN;
                float wx2 = dx2 * SN - dy2 * CN;
                float wz2 = dx2 * CN + dy2 * SN;

                // if z1 & z2 < 0 (wall completely behind player) -- skip it!
                // if z1 or z2 is behind the player -> clip it!
                if (wz1 < 0 && wz2 < 0)
                    continue;
                else if (wz1 < 0)
                    (wx1, wz1) = R_ClipBehindPlayer(wx1, wz1, wx2, wz2);
                else if (wz2 < 0)
                    (wx2, wz2) = R_ClipBehindPlayer(wx2, wz2, wx1, wz1);

                // calc wall height based on distance
                float wh1 = (sector_h / wz1) * fov;
                float wh2 = (sector_h / wz2) * fov;

                // convert to screen space
                float sx1 = (wx1 / wz1) * fov;
                float sy1 = ((gameState.ScreenHeight + player.Z) / wz1);
                float sx2 = (wx2 / wz2) * fov;
                float sy2 = ((gameState.ScreenHeight + player.Z) / wz2);

                // calc wall elevation from the floor
                float s_level1 = (sector_e / wz1) * fov;
                float s_level2 = (sector_e / wz2) * fov;
                sy1 -= s_level1;
                sy2 -= s_level2;

                //construct portal top and bottom
                float pbh1 = 0;
                float pbh2 = 0;
                float pth1 = 0;
                float pth2 = 0;
                if (w.IsPortal)
                {
                    pth1 = (w.PortalTopHeight / wz1) * fov;
                    pth2 = (w.PortalBottomHeight / wz2) * fov;
                    pbh1 = (w.PortalBottomHeight / wz1) * fov;
                    pbh2 = (w.PortalBottomHeight / wz2) * fov;
                }

                // set screen-space origin to center of the screen
                sx1 += screenHalfWidth;
                sy1 += screenHalfHeight;
                sx2 += screenHalfWidth;
                sy2 += screenHalfHeight;

                // // top
                // R_DrawLine(sx1, sy1 - wh1, sx2, sy2 - wh2, wallColor);
                // // bottom
                // R_DrawLine(sx1, sy1, sx2, sy2, wallColor);
                // // left edge
                // R_DrawLine(sx1, sy1 - wh1, sx1, sy1, wallColor);
                // // right edge
                // R_DrawLine(sx2, sy2 - wh2, sx2, sy2, wallColor);

                //if (w.IsPortal)
                //{
                //    R_DrawLine(sx1, sy1 - wh1 + pth1, sx2, sy2 - wh2 + pth2, wallColor);
                //    R_DrawLine(sx1, sy1 - pbh1, sx2, sy2 - pbh2, wallColor);
                //}

                if (w.IsPortal)
                {
                    // top
                    Quad qt = R_CreateRenderableQuad(sx1, sx2, sy1 - wh1, sy1 - wh1 + pth1, sy2 - wh2, sy2 - wh2 + pth2);
                    // bottom
                    Quad qb = R_CreateRenderableQuad(sx1, sx2, sy1 - pbh1, sy1, sy2 - pbh2, sy2);

                    R_Rasterize(qt, s.CeilingColor, IS_CEIL, s.PortalsCeilingXYLookUpTable);
                    R_Rasterize(qt, s.FloorColor, IS_FLOOR, s.PortalsFloorXYLookUpTable);
                    R_Rasterize(qt, s.WallColor, IS_WALL, null);

                    R_Rasterize(qb, s.CeilingColor, IS_CEIL, s.CeilingXYLookUpTable);
                    R_Rasterize(qb, s.FloorColor, IS_FLOOR, s.FloorXYLookUpTable);
                    R_Rasterize(qb, s.WallColor, IS_WALL, null);
                }
                else
                {
                    Quad q = R_CreateRenderableQuad(sx1, sx2, sy1 - wh1, sy1, sy2 - wh2, sy2);
                    R_Rasterize(q, s.CeilingColor, IS_CEIL, s.CeilingXYLookUpTable);
                    R_Rasterize(q, s.FloorColor, IS_FLOOR, s.FloorXYLookUpTable);
                    R_Rasterize(q, s.WallColor, IS_WALL, null);
                }
            }

            // rasterize sector's ceil & floor
            for (int x = 0; x < 1024; x++)
            {
                // walls
                int cy1 = s.CeilingXYLookUpTable.T[x];
                int cy2 = s.CeilingXYLookUpTable.B[x];
                int fy1 = s.FloorXYLookUpTable.T[x];
                int fy2 = s.FloorXYLookUpTable.B[x];

                // portals
                int pcy1 = s.PortalsCeilingXYLookUpTable.T[x];
                int pcy2 = s.PortalsCeilingXYLookUpTable.B[x];
                int pfy1 = s.PortalsFloorXYLookUpTable.T[x];
                int pfy2 = s.PortalsFloorXYLookUpTable.B[x];

                // rasterize walls ceil & floor
                if ((player.Z > s.Elevation + s.Height) && (cy1 > cy2) && (cy1 != 0 && cy2 != 0))
                {
                    R_DrawLine(x, cy1, x, cy2, s.CeilingColor);
                }

                if ((player.Z < s.Elevation) && (fy1 < fy2) && (fy1 != 0 || fy2 != 0))
                {
                    R_DrawLine(x, fy1, x, fy2, s.FloorColor);
                }

                // rasterize portals ceil & floor
                if (pcy1 > pcy2 && (pcy1 != 0 && pcy2 != 0))
                {
                    R_DrawLine(x, pcy1, x, pcy2, s.CeilingColor);
                }

                if (pfy1 < pfy2 && (pfy1 != 0 || pfy2 != 0))
                {
                    R_DrawLine(x, pfy1, x, pfy2, s.FloorColor);
                }

            }
        }
    }

    private void R_DrawLine(int x0, int y0, int x1, int y1, uint color)
    {
        byte r = (byte)((color >> 16) & 0xFF);
        byte g = (byte)((color >> 8) & 0xFF);
        byte b = (byte)(color & 0xFF);

        var tColor = Color.FromBytes(r, g, b);
        Gfx.DrawLine(new PointI(x0, y0), new PointI(x1, y1), tColor, BlendModes.Opaque);
    }
    private void R_Rasterize(Quad q, uint color, int ceil_floor_wall, PlaneLookUpTable? xy_lut)
    {
        // if back-facing wall then do not rasterize
        if (ceil_floor_wall == IS_WALL && q.ax > q.bx)
            return;

        bool is_back_wall = false;

        if ((ceil_floor_wall != IS_WALL) && q.ax > q.bx)
        {
            R_SwapQuadPoints(ref q);
            is_back_wall = true;
        }

        float delta_height, delta_elevation;

        (delta_height, delta_elevation) = R_CalcInterpolationFactors(q);
        if (delta_height == -1 && delta_elevation == -1)
            return;

        for (int x = q.ax, i = 1; x < q.bx; x++, i++)
        {
            if (x < 0 || x > ScreenWidth - 1) continue;

            float dh = delta_height * i;
            float dy_player_elev = delta_elevation * i;

            int y1 = (int)(q.at - (dh / 2) + dy_player_elev);
            int y2 = (int)(q.ab + (dh / 2) + dy_player_elev);

            y1 = R_CapToScreenH(y1);
            y2 = R_CapToScreenH(y2);

            if (ceil_floor_wall == IS_CEIL)
            {
                // save the ceiling Y coordinates for each X coordinate
                if (!is_back_wall)
                    xy_lut.Value.T[x] = y1;
                else
                    xy_lut.Value.B[x] = y1;
            }
            else if (ceil_floor_wall == IS_FLOOR)
            {
                // save the floor's Y coordinates for each X coordinate
                if (!is_back_wall)
                    xy_lut.Value.T[x] = y2;
                else
                    xy_lut.Value.B[x] = y2;
            }
            else
            {
                // rasterize
                R_DrawLine(x, y1, x, y2, color);

                if (gameState.IsDebugMode)
                {
                    //R_UpdateScreen();
                    //SDL_Delay(10);
                }
            }
        }
    }

    private int R_CapToScreenH(int val)
    {
        if (val < 0) val = 0;
        if (val > ScreenHeight) val = ScreenHeight;

        return val;
    }

    private (float delta_height, float delta_elevation) R_CalcInterpolationFactors(Quad q)
    {
        // absolute width
        int width = Math.Abs(q.ax - q.bx);
        if (width == 0)
        {
            return (-1, -1);
        }

        // calc height increment
        int a_height = q.ab - q.at;
        int b_height = q.bb - q.bt;

        var delta_height = (float)(b_height - a_height) / (float)width;

        // get player's view elevation from the floor
        int y_center_a = (q.ab - (a_height / 2));
        int y_center_b = (q.bb - (b_height / 2));

        var delta_elevation = (y_center_b - y_center_a) / (float)width;
        return (delta_height, delta_elevation);
    }

    private void R_SwapQuadPoints(ref Quad q)
    {
        (q.ax, q.bx) = (q.bx, q.ax);
        (q.at, q.bt) = (q.bt, q.at);
        (q.ab, q.bb) = (q.bb, q.ab);
    }

    private Quad R_CreateRenderableQuad(float ax, float bx, float at, float ab, float bt, float bb)
    {
        return new()
        {
            ax = (int)ax,
            bx = (int)bx,
            at = (int)at,
            bt = (int)bt,
            ab = (int)ab,
            bb = (int)bb
        };
    }

    private (float ax, float ay) R_ClipBehindPlayer(float ax, float ay, float bx, float by)
    {
        float px1 = 1;
        float py1 = 1;
        float px2 = 200;
        float py2 = 1;

        float a = (px1 - px2) * (ay - py2) - (py1 - py2) * (ax - px2);
        float b = (py1 - py2) * (ax - bx) - (px1 - px2) * (ay - by);

        float t = a / b;

        return (ax - (t * (bx - ax)), ay - (t * (by - ay)));

        // *ax = *ax - (t * (bx - *ax));
        // *ay = *ay - (t * (by - *ay));
    }

    private void R_SortSectorsByDistToPlayer(PointF playerPosition)
    {
        for (int i = 0; i < sectorQueue.Count; i++)
        {
            PointF centroid = R_CalcCentroid(sectorQueue[i]);
            sectorQueue[i].DistanceToPlayer = R_DistanceToPoint(playerPosition, centroid);
        }

        // sort sectors by distance to player
        for (int i = 0; i < sectorQueue.Count - 1; i++)
        {
            for (int j = 0; j < sectorQueue.Count - i - 1; j++)
            {
                if (sectorQueue[j].DistanceToPlayer < sectorQueue[j + 1].DistanceToPlayer)
                {
                    (sectorQueue[j + 1], sectorQueue[j]) = (sectorQueue[j], sectorQueue[j + 1]);
                }
            }
        }
    }

    private PointF R_CalcCentroid(Sector s)
    {
        PointF centroid = new(0, 0);

        foreach (var wall in s.Walls)
        {
            centroid.X += wall.A.X;
            centroid.Y += wall.A.Y;
        }

        centroid.X /= s.NumberOfWalls * 2;
        centroid.Y /= s.NumberOfWalls * 2;

        return centroid;
    }

    private float R_DistanceToPoint(PointF a, PointF b)
    {
        return MathF.Sqrt(MathF.Pow(a.X - b.X, 2) + MathF.Pow(a.Y - b.Y, 2));
    }

    public Sector R_CreateSector(int height, int elevation, uint color, uint ceilingColor, uint floorColor)
    {
        return new Sector(0, new(), height, elevation, 0, color, floorColor, ceilingColor, new PlaneLookUpTable(), new PlaneLookUpTable(), new PlaneLookUpTable(), new PlaneLookUpTable());
    }

    public void R_SectorAddWall(Sector sector, Wall vertices)
    {
        sector.Walls.Add(vertices);
    }

    public void R_AddSectorToQueue(Sector sector)
    {
        sectorQueue.Add(sector);
    }

    public Wall R_CreateWall(int ax, int ay, int bx, int by)
    {
        return new Wall(new PointF(ax, ay), new PointF(bx, by), 0, 0, false);
    }

    public Wall R_CreatePortal(int ax, int ay, int bx, int by, int th, int bh)
    {
        return new Wall(new PointF(ax, ay), new PointF(bx, by), th, bh, true);
    }

    public static Color FromRGB(uint rgb)
    {
        byte r = (byte)((rgb >> 16) & 0xFF);
        byte g = (byte)((rgb >> 8) & 0xFF);
        byte b = (byte)(rgb & 0xFF);

        var color = new Color(r, g, b);
        return color;
    }
}
