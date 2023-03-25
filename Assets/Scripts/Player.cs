using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public bool isGrounded;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public int score;
    public Text scoreText; 
    public int maxHealth = 100; // максимальное здоровье
    private int currentHealth; // текущее здоровье


    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        
        // нужно убрать     
        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * 0.1f; 

        transform.position = position;
        // нужно убрать...
        
    }

    void Update() 
    {   
        // нужно убрать
        if(Input.GetKeyDown(KeyCode.W) && isGrounded) // пробел
        {
            Jump();
        } 
        // нужно убрать...

        // при падении загружаем сцену заново, нужно смотреть на жизни если закончились то на меню
        if(transform.position.y < -5.7f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }

        // нужно убрать
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
        // нужно убрать

    }

    // нужно убрать
    public void Jump() // прыжок
    {
        if(isGrounded) // прыгать можно с поверхности
        {
            isGrounded = false;
            rigidbody2d.AddForce(transform.up * 4f, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

    }
    // нужно убрать...
    
    // при приземлении на поверхность после прыжка
    public void OnCollisionEnter2D(Collision2D other)   
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }      
    }

    public void AddCoin(int count)
    {
        score += count;
        //scoreText.text = score.ToString();
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;    
        
        if(currentHealth<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
        }
  
    }

}
