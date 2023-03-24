using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;
    //public AudioClip audioClip;
    public int count;

    //private AudioSource audioSource;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //audioSource = GetComponent<AudioSource>();        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().AddCoin(count);
            other.GetComponent<AudioSource>().Play();
            //audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }

}
