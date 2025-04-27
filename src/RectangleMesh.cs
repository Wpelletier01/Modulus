namespace Modulus;

using OpenTK.Graphics.OpenGL4;

public class RectangleMesh
{

	private static RectangleMesh instance;

	private int vertexBufferObject;
	private int vertexArrayObject;
	private int elementBufferObject;

    private readonly float[] vertices =
    {
		-0.1f, 0.1f,  0.0f, // top left
		0.1f,  0.1f,  0.0f, // top right
		0.1f,  -0.1f, 0.0f, // bottom right
		-0.1f, -0.1f, 0.0f  // bottom left
    };

    private readonly uint[] indices =
    {
        0, 1, 2, // top left one
        0, 3, 2  // bottom right one
    };

	private RectangleMesh() {}


	public static RectangleMesh getInstance()
	{
		if (instance == null)
		{
			instance = new RectangleMesh();
		}

		return instance;

	}


	public void load()
	{

		vertexBufferObject = GL.GenBuffer();
		GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
		GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

		vertexArrayObject = GL.GenVertexArray();
		GL.BindVertexArray(vertexArrayObject);
		GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
		GL.EnableVertexAttribArray(0);

		elementBufferObject = GL.GenBuffer();
		GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
		GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);


	}

	public void draw()
	{
		GL.BindVertexArray(vertexArrayObject);
		GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt,0);
	}

	public int getIndicesLenght()
	{
		return indices.Length;
	}

}
