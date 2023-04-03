using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject Player;
    private bool keyDown;
    public float speed = 0.1f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        animator = Player.GetComponent<Animator>();
        spriteRenderer = Player.GetComponent<SpriteRenderer>();    
    }

    void OnMouseDown()
    {
        transform.localScale = new Vector3(1.07f, 1.07f, 1.07f);
        keyDown = true;

        if(gameObject.name == "B")
        {
            animator.SetInteger("State", 0);
            Player.GetComponent<Player>().Jump();     
        }
        else if(gameObject.name == "A")
        {
            animator.SetInteger("State", 0);
            Player.gameObject.GetComponent<PlayerAtack>().Atack();
        }
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        keyDown = false;
        animator.SetInteger("State", 0);
    }


    private void Update() 
    {
        if(keyDown)
        {
            Behabior();
        }    
    }

    private void Behabior()
    {
     
        Vector3 position = Player.transform.position;
     
        switch(gameObject.name) 
        {
            case "Left":                   
                position.x -= 1 * speed; 
                spriteRenderer.flipX = true;
                animator.SetInteger("State", 1);
                
                break;
            case "Right":
                position.x += 1 * speed;          
                spriteRenderer.flipX = false;
                animator.SetInteger("State", 1);
                        
                break;
            case "B":           
                animator.SetInteger("State", 0);
                break;
        }

        Player.transform.position = position;

    }


}
