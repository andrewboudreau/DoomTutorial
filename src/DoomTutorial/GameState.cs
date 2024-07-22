namespace DoomTutorial;

public class GameState
{
    public int FrameStart { get; private set; } = 0;

    public GameState(int screenWidth, int screenHeight, int targetFps)
    {
        IsDebugMode = false;
        IsRunning = true;

        ScreenWidth = screenWidth;
        ScreenHeight = screenHeight;

        TargetFps = targetFps;
        TargetFrameTime = 1.0f / (float)targetFps;
        
        IsFpsCapped = false;
        DeltaTime = 0;
        IsPaused = false;
        
        StateShowMap = false;
    }

    public int ScreenWidth { get; }
    public int ScreenHeight { get; }
    public float TargetFps { get; }
    public float TargetFrameTime { get; set; }
    public float DeltaTime { get; set; }
    public bool IsRunning { get; set; }
    public bool IsPaused { get; set; }
    public bool IsFpsCapped { get; set; }
    public bool StateShowMap { get; set; }
    public bool IsDebugMode { get; set; }
}
