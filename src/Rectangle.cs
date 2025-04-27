namespace Modulus;

using OpenTK.Mathematics;

public class Rectangle
{

    Matrix4 model;

	public Rectangle(float top, float left, float width, float height)
	{
        model = Matrix4.CreateScale(width, height, 1f);
        model *= Matrix4.CreateTranslation(top, left, 0f);
    }

    public Matrix4 getModel() { return model; }


}
