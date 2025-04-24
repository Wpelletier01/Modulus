namespace Modulus;

public abstract class Event {

    private static int EVENT_COUNTER = 1;

    private int id { get;  }

	public Event() {
        id = EVENT_COUNTER;
        EVENT_COUNTER++;
    }


}
