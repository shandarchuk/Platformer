using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{

    public Animator animator;
    public Transform atackPoint;
    public float atackRange = 0.5f;
    public LayerMask enemyLayers;

    public int atackDamage = 0;

    void Update()
    {
        // нужно убрать
        if(Input.GetKeyDown(KeyCode.F)) //удар клавишей F в дальнейшем переделать на кнопки 
        {
            Atack();
        }
        // нужно убрать

    }

    public void Atack()
    {
        //анимация атаки
        animator.SetTrigger("player_atack");
        
        //обнаружить врагов в зоне действия 
        //определеяет радиус вокруг позиции, создает круг, и помещаем их в массив
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(atackPoint.position, atackRange, enemyLayers); 
        
        //нанести урон врагам 
        foreach(Collider2D enemy in hitEnemies)   
        {
            //Debug.Log("Ударили " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(atackDamage); // наносим урон
        }
    }


    void OnDrawGizmosSelected() // позволяет отоброзить материал когда объект выбран
    {
        if (atackPoint != null)
            Gizmos.DrawWireSphere(atackPoint.position, atackRange);   
    }

}

