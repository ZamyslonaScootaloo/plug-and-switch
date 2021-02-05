using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

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
    void Start()
    {
        StartCoroutine(LateStart());
    }
    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.01f);
        plug = GameObject.Find("Plug");
        plug.transform.position = (Vector2)plugPosition;
        plug.GetComponent<Plug>().SetRotation( plugPosition - enterance);
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Battery"))
        {
            batteries.Add(g.GetComponent<Battery>());
        }
        Refresh();
    }


    List<Battery> batteries = new List<Battery>();

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

        foreach (Battery b in batteries)
            b.Refresh();
    }
}
