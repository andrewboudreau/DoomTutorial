using BonEngineSharp;
using BonEngineSharp.Framework;


using var doom = new DoomScene();

_ = Task.Run(() => {
    Thread.Sleep(1000);
    doom.Log.Warn("omg!!!");
    Thread.Sleep(1000);
});

BonEngine.Start(doom);


class DoomScene : Scene
{
    // called when scene loads
    protected override void Load()
    {
    }

    // called when scene unloads
    protected override void Unload()
    {
    }

    // called every frame to do updates
    protected override void Update(double deltaTime)
    {
    }

    // called every frame to draw scene
    protected override void Draw()
    {
        Gfx.DrawRectangle(new RectangleI(50, 50, 25, 25), Color.Red, true);
    }

    // called every constant interval to update physics related stuff
    protected override void FixedUpdate(double deltaTime)
    {
    }
}