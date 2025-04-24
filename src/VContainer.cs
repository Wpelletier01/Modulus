namespace Modulus;


public class VContainer : NodeContainer
{

    public VContainer(double x, double y) : base(x, y) { }

    public override void addChild(Node child)
    {

        children.Add(child);

        Vector2<double> bigger = getBiggerChildSize();

        setWidth(bigger.x);
        setHeight(bigger.y * children.Count);

        Vector2<double> destination = new Vector2<double>(position.x, position.y);

        foreach (Node c in children)
        {
            c.move(destination);
            c.setWidth(bigger.x);
            c.setHeight(bigger.y);
            destination.y += bigger.y;

        }

    }

    public override bool removeChild(Node child) { return children.Remove(child); }


}
