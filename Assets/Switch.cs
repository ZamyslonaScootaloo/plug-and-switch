using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    static Vector2[] DIRECTIONS = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

    public bool[] connections = new bool[4];

    public LayerMask obstacles;
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

                Collider2D hit = Physics2D.OverlapPoint(transform.position + (Vector3)DIRECTIONS[i], obstacles);
                if (hit)
                    hit.transform.gameObject.SendMessage("Power", new Arguments(DIRECTIONS[i], false, args.off));
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

            transform.Rotate(0, 0, -90);
        }

        for (int i = 0; i < 4; i++)
        {
            if (!connections[i])
                continue;
            if (DIRECTIONS[i] == -args.source)
                continue;

            Collider2D hit = Physics2D.OverlapPoint(transform.position + (Vector3)DIRECTIONS[i], obstacles );
            if (hit) 
                hit.transform.gameObject.SendMessage("Power", new Arguments(DIRECTIONS[i], args.control, args.off));
        }
    }
}
