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
        if (!args.off)
        {
            gameObject.tag = "Untagged";
            spriteRenderer.color = new Color(0, 0, 0, 0);
        }
        else
        {
            gameObject.tag = "Wall";
            spriteRenderer.color = new Color(255, 255, 255, 1);
        }
    }
}
