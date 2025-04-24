namespace Modulus;

public abstract class NodeContainer : Node
{

    private static double DEFAULT_SIZE = 100;

    protected List<Node> children { get; }

    public NodeContainer(double x, double y) : base(x, y, DEFAULT_SIZE, DEFAULT_SIZE)
    {
        children = new List<Node>();

    }

    public abstract void addChild(Node child);
    public abstract bool removeChild(Node child);
    public List<Node> getChildren()
    {
        return children;
    }

    protected Vector2<double> getBiggerChildSize()
	{

        Vector2<double> biggest = new Vector2<double>(0, 0);

        foreach(Node child in children) {

			if (child.getWidth() > biggest.x) {
                biggest.x = child.getWidth();
            }

			if (child.getHeight() > biggest.y) {
                biggest.y = child.getHeight();
            }


		}

        return biggest;

    }


}
