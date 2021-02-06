using UnityEngine;

public class RemotePlug : MonoBehaviour
{
    public Plug plug;

    public void Power(Arguments args)
    {
        if (args.off)
            plug.on = false;
        else
            plug.on = true;
    }
}
