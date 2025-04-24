namespace Modulus;


public class EventSystem {
	private static EventSystem instance;

    private List<Node> nodes = new List<Node>();



	private EventSystem() {

    }

	public static EventSystem getInstance() {
		if (instance == null) {
            instance = new EventSystem();
        }

        return instance;

    }

    public void addNode(Node node) {
        nodes.Add(node);
    }

	public void removeNode(Node node) {
        nodes.Remove(node);
    }

	// here should be where the event system receive the event from
	// a framework

	public void propagateMouseMoveEvent(double x, double y) {



        MouseMoveEvent mEvent = new MouseMoveEvent(x, y);

        List<Node> hoveringOver = new List<Node>();

		foreach(Node node in nodes) {

			if (node.isHovering(mEvent.position)) hoveringOver.Add(node);

		}

        // TODO: surely we have better sort algorithm

		if (hoveringOver.Count == 0) return;

        int i = 1;

		while (i < hoveringOver.Count) {
            int j = i;
			while (j > 0 && hoveringOver[j-1].getZLayerPos() > hoveringOver[j].getZLayerPos()) {
                Node tmp = hoveringOver[j];
				hoveringOver[j] = hoveringOver[j-1];
                hoveringOver[j - 1] = tmp;
                j--;
            }
            i++;
        }


        Node last = hoveringOver.Last();

        last.setZLayerPos(1);  // now it become the first in context
		last.handleEvent(mEvent);

	}









}
