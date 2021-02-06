using System.Collections;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public Sprite[] sprites;
    
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Power(Arguments args)
    {
        spriteRenderer.sprite = sprites[args.off ? 0 : 1];
        gameManager.PlaySound("b");
        if (gameManager.testMode)
            return;


        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
            Destroy(g.GetComponent<Plug>());

        if (!args.off)
            StartCoroutine(Continue());
    }

    public IEnumerator Continue()
    {
        yield return new WaitForSeconds(1);
        gameManager.NextLevel();
    }
}
