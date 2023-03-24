using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBonus : MonoBehaviour
{

    public Sprite bigSprite;
    public Sprite smallSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().ScaleBonus();

            Destroy(gameObject);
        }    
    }
}
