using UnityEngine;


public class Condurctor : MonoBehaviour
{
    static Vector2[] DIRECTIONS = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    
    public bool[] connections = new bool[4];
    public LayerMask obstacles;
    
    public void Power(Arguments args)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!connections[i])
                continue;
            if (DIRECTIONS[i] == -args.source)
                continue;

            Collider2D hit = Physics2D.OverlapPoint(transform.position + (Vector3)DIRECTIONS[i] + new Vector3(0.5f, 0.5f), obstacles);

            if (hit)
                hit.transform.gameObject.SendMessage("Power", new Arguments(DIRECTIONS[i], args.control, args.off), SendMessageOptions.DontRequireReceiver);
        }
    }
}