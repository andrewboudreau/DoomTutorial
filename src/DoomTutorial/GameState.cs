namespace DoomTutorial;

public class GameState
{
    public int FrameStart { get; set; } = 0;

    public GameState(int screenWidth, int screenHeight, int targetFrameRate)
    {
        ScreenWidth = screenWidth;
        ScreenHeight = screenHeight;

        TargetFrameRate = targetFrameRate;
        TargetFrameTime = 1.0f / (float)targetFrameRate;

        IsRunning = true;
        IsDebugMode = false;

        DeltaTime = 0;
        IsPaused = false;
        IsFrameRateLocked = false;
        StateShowMap = false;
    }

    public int ScreenWidth { get; }
    public int ScreenHeight { get; }
    public float TargetFrameRate { get; }
    public float TargetFrameTime { get; set; }
    public float DeltaTime { get; set; }
    public bool IsRunning { get; set; }
    public bool IsPaused { get; set; }
    public bool IsFrameRateLocked { get; set; }
    public bool StateShowMap { get; set; }
    public bool IsDebugMode { get; set; }
}
