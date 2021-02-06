using UnityEngine;

public class Wire : MonoBehaviour
{
    public Sprite[] sprites;
    [HideInInspector] public bool[] outs = new bool[4];

    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Refresh()
    {
        if(outs[0])
        {
            if (outs[1]) spriteRenderer.sprite = sprites[2];
            else if (outs[3]) spriteRenderer.sprite = sprites[5];
            else spriteRenderer.sprite = sprites[1];
        }
        else if (outs[2])
        {
            if (outs[1]) spriteRenderer.sprite = sprites[3];
            else if (outs[3]) spriteRenderer.sprite = sprites[4];
            else spriteRenderer.sprite = sprites[1];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }
    }

    public static int DirectionToIndex(Vector2Int direction)
    {
        int i = 0;

        if (direction == Vector2Int.right)
            i = 1;
        else if (direction == Vector2Int.down)
            i = 2;
        else if (direction == Vector2Int.left)
            i = 3;

        return i;
    }
}
