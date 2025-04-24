namespace Modulus;

public class MathUtils
{


    public static double CalculateTriangleArea(Vector2<double> p1, Vector2<double> p2, Vector2<double> p3)
    {
        return Math.Abs(0.5 * (p1.x * (p2.y - p3.y) + p2.x * (p3.y - p1.y) + p3.x * (p1.y - p2.y)));
    }


}
