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
    public float maxHealth = 100; // максимальное здоровье
    private float currentHealth; // текущее здоровье

    public Image healthBar; // жизни

    public AudioSource audioSource;

    public AudioClip[] audioClips;


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

    private void Update() 
    {   
        // нужно убрать
        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        } 
        // нужно убрать...

        // при падении загружаем сцену заново, нужно смотреть на жизни если закончились то на меню
        if(transform.position.y < -5.7f)
        {
            SceneManager.LoadScene("Menu");  
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
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

    // прыжок
    public void Jump() 
    {
        // прыгать можно с поверхности
        if(isGrounded) 
        {
            // звук прыжка
            PlayAudioClip(1);

            isGrounded = false;
            rigidbody2d.AddForce(transform.up * 4f, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            
        }

    }
    
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
        scoreText.text = "Total: " + score.ToString();
    }

    public void TakeDamage(int damage)
    {

        PlayAudioClip(3);
        
        animator.SetTrigger("Hurt");
        currentHealth -= damage;    
        
        HealthBar();

        if(currentHealth<=0)
        {
            SceneManager.LoadScene("Menu");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
        }
  
    }


    public void PlayAudioClip(int index, bool loop=false)
    {
        audioSource.clip = audioClips[index];
        audioSource.loop = false;
        audioSource.Play();   
    }

    public void HealthBar()
    {
        healthBar.fillAmount = currentHealth/100; 
    }

}
