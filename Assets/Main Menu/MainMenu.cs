using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static int NUMBER_OF_LEVELS = 4;
    public Sprite[] mains;
    public Sprite[] levels;

    private bool main = true;

    private SpriteRenderer spriteRenderer;



    private List<GameObject> highlights = new List<GameObject>();
    private List<GameObject> padlocks = new List<GameObject>();

    int page = 0;
    int level = 0;
    int available = 0;


    int index = 0;

    AudioSource audioSource;
    public AudioClip[] clips = new AudioClip[2];

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject c = transform.GetChild(i).gameObject;

            if (c.CompareTag("Highlight"))
                highlights.Add(c);
            else if (c.CompareTag("Padlock"))
                padlocks.Add(c);

            c.SetActive(false);
        }



        available = GetSave();
        Debug.Log(available);
    }
    
    private void Update()
    {
        if (main)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                index--;

                if (index < 0)
                    index = 2;

                audioSource.clip = clips[0];
                audioSource.Play();

                spriteRenderer.sprite = mains[index];
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                index++;

                if (index > 2)
                    index = 0;

                audioSource.clip = clips[0];
                audioSource.Play();

                spriteRenderer.sprite = mains[index];
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {

                audioSource.clip = clips[1];
                audioSource.Play();

                // Kto powiedział, że nie umiem w słicze?
                switch (index)
                {
                    case 0:

                        for (int i = 0; i < 8; i++)
                        {
                            if (i < available && i < NUMBER_OF_LEVELS)
                                continue;

                            padlocks[i].SetActive(true);
                        }

                        highlights[0].SetActive(true);
                        spriteRenderer.sprite = levels[0];
                        main = false;
                        break;

                    case 1:
                        Debug.Log("Twórcy");
                        break;

                    case 2:
                        Application.Quit();
                        break;
                }
            }
        }
        // Wybór poziomów!
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (index <= 3)
                    return;

                ChangeLevel(-4);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (index == 0 || index == 4)
                    return;

                ChangeLevel(-1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (index >= 4)
                    return;

                ChangeLevel(4);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (index == 3 || index == 7)
                    return;

                ChangeLevel(1);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {

                for (int i = 0; i < 8; i++)
                {
                    padlocks[i].SetActive(false);
                    highlights[i].SetActive(false);
                }

                spriteRenderer.sprite = mains[0];
                index = 0;
                main = true;
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                if (available > index && index < NUMBER_OF_LEVELS)
                {
                    StartCoroutine(LoadScene(1 + index + page * 8));

                    audioSource.clip = clips[1];
                    audioSource.Play();
                }
            }
        }
    }
    IEnumerator LoadScene(int id)
    {
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene(id);
    }

    private void ChangeLevel(int offset) 
    {

        audioSource.clip = clips[0];
        audioSource.Play();

        highlights[index].SetActive(false);
        index += offset;
        highlights[index].SetActive(true);
    }
    private static int GetSave()
    {
        string path = Application.persistentDataPath + "/save.zsrr";

        if (File.Exists(path))
        {
            int i =  int.Parse(File.ReadAllText(path));

            if (i > 0)
                return i + 1;
        }

        return 1;
    }
}
