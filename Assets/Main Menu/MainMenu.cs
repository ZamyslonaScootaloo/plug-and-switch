using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    int index = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            index--;

            if (index < 0)
                index = 2;

            spriteRenderer.sprite = sprites[index];
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            index++;

            if (index > 2)
                index = 0;

            spriteRenderer.sprite = sprites[index];
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            switch(index)
            {
                case 0:
                    Debug.Log("Wybór poziomów");
                    break;

                case 1:
                    Debug.Log("Twórcy");
                    break;

                case 2:

                    // Jej można wyjść, nie tak jak w Vimie =)
                    Application.Quit();
                    break;
                }
        }
    }
}
