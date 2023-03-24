using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed, jumpForce, timerSpeed, timerSpeedMax, speedBonus;

    private float speedStart;
    private bool isGrounded;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public int score;
    public Text scoreText;
    public int health = 5;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        speedStart = speed; 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // записываем координаты игрока
        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed; 

        transform.position = position;

        if(timerSpeed > 0)
        {
            speed = speedBonus;
            timerSpeed--;
        }
        else
        {
            speed = speedStart;
        }

    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) // пробел
        {
            Jump();
        } 

        // при падении
        if(transform.position.y < -5.7f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // загружаем сцену заново, нужно смотреть на жизни если закончились то на меню
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            if(Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            } 
            else if(Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
            }

            animator.SetInteger("State", 1);
        }
        else
        {
            animator.SetInteger("State", 0);    
        }

    }

    private void Jump() // прыжок
    {
        if(isGrounded) // прыгать можно с поверхности
        {
            isGrounded = false;
            rigidbody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    
    public void OnCollisionEnter2D(Collision2D other) // при приземлении на поверхность после прыжка  
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        
    }

    public void AddCoin(int count)
    {
        score += count;
        scoreText.text = score.ToString();
    }

    public void SpeedBonus()
    {
        timerSpeed = timerSpeedMax;
    }

    public void ScaleBonus()
    {
        transform.localScale = new Vector3(1.5f,1.5f,1);
    }

}
