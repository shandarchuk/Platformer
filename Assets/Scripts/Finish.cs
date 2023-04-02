using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            int score = other.gameObject.GetComponent<Player>().score;
            PlayerPrefs.SetInt("tempScore", score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }    
    }
}
