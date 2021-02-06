using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    static Vector2[] DIRECTIONS = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    public int turn;
    public Sprite[] sprites = new Sprite[4];
    public bool[] connections = new bool[4];

    public LayerMask obstacles;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        for(int a = 0; a < turn; a++)
        {
            bool[] c = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                int n = i - 1;

                if (n < 0)
                    n = 3;

                c[i] = connections[n];
            }

            connections = c;
        }

        spriteRenderer.sprite = sprites[turn % 4];
    }

    public void Power(Arguments args)
    {
    

        // Kręcenie się!
        if (args.control)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!connections[i])
                    continue;
                if (DIRECTIONS[i] == -args.source)
                    continue;

                Collider2D hit = Physics2D.OverlapPoint(transform.position + (Vector3)DIRECTIONS[i] + new Vector3(0.5f, 0.5f), obstacles);

                if (hit)
                    hit.transform.gameObject.SendMessage("Power", new Arguments(DIRECTIONS[i], false, true), SendMessageOptions.DontRequireReceiver);
            }


            bool[] c = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                int n = i - 1;

                if (n < 0)
                    n = 3;

                c[i] = connections[n];
            }

            connections = c;

            turn++;
            turn %= 4;
            spriteRenderer.sprite = sprites[turn];
        }

        for (int i = 0; i < 4; i++)
        {
            if (args.source == -DIRECTIONS[i])
            {
                if (!connections[i])
                    return;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (!connections[i])
                continue;
            if (DIRECTIONS[i] == -args.source)
                continue;

            Collider2D hit = Physics2D.OverlapPoint(transform.position + (Vector3)DIRECTIONS[i] + new Vector3(0.5f, 0.5f), obstacles );
            if (hit) 
                hit.transform.gameObject.SendMessage("Power", new Arguments(DIRECTIONS[i], false, args.off));
        }
    }
}
