namespace Modulus;

public class MObject
{

    private static int INSTANCE_CTN = 1;

    private int id { get; }

    public MObject()
    {
        id = INSTANCE_CTN;
        INSTANCE_CTN++;
    }

    public virtual bool handleEvent(Event e)
	{
		// default
        return false;
    }
}
