namespace Modulus;

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public static class Program
{
    private static void Main()
    {
        var nativeWindowSettings = new NativeWindowSettings()
        {
            ClientSize = new Vector2i(800, 600),
            Title = "Modulus testing",
            Flags = ContextFlags.ForwardCompatible,
        };

        Window window = new Window(GameWindowSettings.Default, nativeWindowSettings);

        window.Run();

    }
}
