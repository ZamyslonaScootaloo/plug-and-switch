using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    const int SIZE_X = 14;
    const int SIZE_Y = 7;

    public Sprite[] numbers = new Sprite[10];

    public SpriteRenderer tens;
    public SpriteRenderer unities;
    
    public Texture2D map;
    public Sprite[] walls;

    

    public int length = 10;

    public Vector2Int enterance = new Vector2Int(0, 0);
    public Vector2Int plugPosition = new Vector2Int(1, 0);
    public GameObject plug;

    public Image prefab;

    private void Start()
    {
        plug = GameObject.Find("Plug");
        plug.transform.position = (Vector2)plugPosition;
        plug.GetComponent<Plug>().SetRotation( plugPosition - enterance);
        Refresh();

        if (!map)
            return;

        for (int x = -1; x < SIZE_X + 1; x++)
        {
            for(int y = -1; y < SIZE_Y + 1; y++)
            {
                Color c = map.GetPixel(x, y);
                
                
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Refresh()
    {
        int u = length % 10;
        int t = (length - u) / 10;

        if (t == 0)
            tens.sprite = null;
        else
            tens.sprite = numbers[t];

        unities.sprite = numbers[u];
    }
}
