namespace Modulus;

using Raylib_cs;

public abstract class Node : MObject {

    protected Vector3<double> position;
    protected double width;
    protected double height;

    public Node(double x, double y, double w, double h) {

        position = new Vector3<double>(x,y,double.NegativeInfinity); // default z layer position
        width = w;
        height = h;
    }

	public void move(Vector2<double> p) {
        position.x = p.x;
        position.y = p.y;
    }

    public void setZLayerPos(double z) { position.z = z; }
    public double getZLayerPos() { return position.z; }

    public void setWidth(double w) { width = w;  }
    public double getWidth() { return width; }

    public void setHeight(double h) { height = h; }
    public double getHeight() { return height; }


    public Vector2<double> getPosition() { return new Vector2<double>(position.x, position.y); }

    public bool isHovering(Vector2<double> p) {

        double rectArea = width * height;

        Vector2<double> pA = new Vector2<double>(position.x, position.y);
        Vector2<double> pB = new Vector2<double>(position.x + width, position.y);
        Vector2<double> pC = new Vector2<double>(position.x, position.y + height);
        Vector2<double> pD = new Vector2<double>(position.x + width, position.y + height);

        double aTriangleAPC = MathUtils.CalculateTriangleArea(pA, p, pC);
        double aTriangleAPB = MathUtils.CalculateTriangleArea(pA, p, pB);
        double aTriangleCPD = MathUtils.CalculateTriangleArea(pC, p, pD);
        double aTriangleBPD = MathUtils.CalculateTriangleArea(pB, p, pD);


        return rectArea == (aTriangleAPC + aTriangleAPB + aTriangleCPD + aTriangleBPD);

	}




}
