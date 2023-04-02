using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Sprite musicOn, musicOff;

    void Start()
    {
        if (PlayerPrefs.GetString("Music") == "off")
            {
                GetComponent<SpriteRenderer>().sprite = musicOff;
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = musicOn;
                Camera.main.GetComponent<AudioListener>().enabled = true;
            }    
    }

    void OnMouseDown()
    {
        transform.localScale = new Vector3(1.07f, 1.07f, 1.07f);
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void Play(int index)
    {
        PlayerPrefs.SetInt("tempScore",0);
        // загружаем сцену по индексу
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void OnMouseUpAsButton()
    {
     
        if(gameObject.name == "Music") 
        {
            OnOffMusic();
        }
        
    }
    
    // Музыка
    private void OnOffMusic()
    {
        if (PlayerPrefs.GetString("Music") == "off")
            {
                GetComponent<SpriteRenderer>().sprite = musicOn;
                PlayerPrefs.SetString("Music", "on");
                Camera.main.GetComponent<AudioListener>().enabled = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = musicOff;
                PlayerPrefs.SetString("Music", "off");
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
    }

}


