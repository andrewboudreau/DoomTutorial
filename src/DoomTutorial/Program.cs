using BonEngineSharp;

using var doom = new DoomScene();

_ = Task.Run(() =>
{
    Thread.Sleep(1000);
    doom.Log.Warn("omg!!!");
});

BonEngine.Start(doom);
