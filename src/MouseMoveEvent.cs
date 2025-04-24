namespace Modulus;

public class MouseMoveEvent : Event {

    public Vector2<double> position;

	public MouseMoveEvent(double x, double y) {

		position = new Vector2<double>(x,y);

    }


}
