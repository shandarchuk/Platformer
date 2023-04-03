using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Enemy : MonoBehaviour
{

    public float speed = 0.01f; // скорость
    public Vector3[] positions; // позиции между которыми он двигается
    
    private int currentTarget = 0; // текущая позиция, для перемещения между позициями positions 

    public int count = 10; // стоимость убитого врага, прибавляется к очкам

    public int maxHealth = 100; // максимальное здоровье
    private int currentHealth; // текущее здоровье

    public Animator animator; // компонент

    public int atackDamage = 0; // урон

    private Vector3 targetPositionPlayer; // позиция игрока при отталкивании при нанесении урона
    public float repulsionRange = 0.8f; // дальность отталкивания

    private void Start() {
        
        currentHealth = maxHealth;
    }

    //получить урон 
    public void TakeDamage(int damage, GameObject player)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;    

        if(currentHealth<=0)
        {
            Die(player);
        }
    }

    void Die(GameObject player) 
    {   
        player.GetComponent<Player>().AddCoin(count);
        Destroy(gameObject); 
    }

    public void FixedUpdate() 
    {
        // двигаем объект к точке, стартовая позиция,конечная,скорость
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed); 

        // если уже на позиции тогда        
        if(transform.position == positions[currentTarget]) 
        {
            if(currentTarget < positions.Length-1)
            {
                currentTarget++;
            }
            else 
            {
                currentTarget = 0;
            }
        }

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }

    }

    

    // если цепляет врага то наносит урон
    private void OnCollisionEnter2D(Collision2D other) 
    {  

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(atackDamage);

            // только игрока
            if(other.gameObject.transform.position.x > gameObject.transform.position.x)
            {     
                targetPositionPlayer = new Vector3(other.transform.position.x + repulsionRange, other.transform.position.y, other.transform.position.z);             
            } 
            else
            {   
                targetPositionPlayer = new Vector3(other.transform.position.x - repulsionRange, other.transform.position.y, other.transform.position.z);             
            }
            other.transform.position = Vector3.MoveTowards(transform.position, targetPositionPlayer, 5);
        }    
    }

}
