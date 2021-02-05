using UnityEngine;

public class Door : MonoBehaviour
{
     SpriteRenderer spriteRenderer;
    public LayerMask wallLayer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    public void Power(Arguments args)
    {
        // Włączanie...
        if (!args.off)
        {
            gameObject.tag = "Untagged";
   
            spriteRenderer.color = new Color(0, 0, 0, 0);
        }
        else {
            gameObject.tag = "Wall";

            // Zamykanie
            Collider2D hit = Physics2D.OverlapPoint(transform.position,    wallLayer);
            spriteRenderer.color = new Color(255, 255, 255, 1);
            if (hit)
            {
                Wire wire = hit.GetComponent<Wire>();
                Plug plug = wire.parent;
                int index = plug.wires.IndexOf(wire);
                plug.stop = index + 1;
            }
        }
    }
}
