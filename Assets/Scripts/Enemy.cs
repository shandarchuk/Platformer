using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float speed = 0.01f;
    public Vector3[] positions;
    public int count;
    private int currentTarget = 0;

    public GameObject tileMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate() 
    {
        // двигаем объект к точке, указываем стартовую позицию, и конечную
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed); 

        if(transform.position == positions[currentTarget]) // если уже на позиции тогда
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

    }

    private void OnCollisionEnter2D(Collision2D other) // если цепляет врага сбоку то игрок умирает, бокс колайдер №2, со всех сторон
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Игрок убит");
            //Destroy(other.gameObject);
            
            SceneManager.LoadScene("Scene"); // загружаем первую сцену, нужно смотреть на жизни если закончились то на меню


            // при столкновении с врагом прыгает вверх и падает вниз      
            /*
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.gameObject.GetComponent<Rigidbody2D>().transform.up * 6, ForceMode2D.Impulse);
            other.gameObject.GetComponent<Rigidbody2D>().mass = 2f;
            Destroy(gameObject);
            tileMap.SetActive(false);
            */

        }    
    }

    private void OnTriggerEnter2D(Collider2D other) // если цепляет врага сбоку то враг умирает бокс колайдер №1, сверху
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Враг убит");
            Destroy(gameObject); // уничтожим врага
            other.GetComponent<Player>().AddCoin(count); // добавим стоимость врага к моенткам
            other.GetComponent<Player>().SpeedBonus(); // активируем бонус скорости
        }   
    }


}
