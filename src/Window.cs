namespace Modulus;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

public class Window : GameWindow
{

    private Shader _shader;

    private List<Rectangle> rectangles = new List<Rectangle>();


    // Add a handle for the EBO
    private int _elementBufferObject;

    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
        : base(gameWindowSettings, nativeWindowSettings)
    {
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

		RectangleMesh.getInstance().load();

        _shader = new Shader("shaders/testing1.vert", "shaders/testing1.frag");
        _shader.Use();

        rectangles.Add(new Rectangle(0f,0f,2.0f,1.2f));
        rectangles.Add(new Rectangle(-0.9f, -0.3f,1.3f, 2f));

    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        _shader.Use();

        var rectMesh = RectangleMesh.getInstance();

        foreach(Rectangle rect in rectangles)
		{
			_shader.SetMatrix4("modelMatrix",rect.getModel());
            rectMesh.draw();
        }

        SwapBuffers();
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        var input = KeyboardState;

        if (input.IsKeyDown(Keys.Escape))
        {
            Close();
        }



    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Size.X, Size.Y);
    }
}
