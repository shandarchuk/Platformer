using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{

    private float timeBetweenAtack; // время между атаками перезарядка
    public float startTimeBetweenAtack;
    public Transform atackPosition; 
    public LayerMask enemy;

    public float atackRange; // дальность атаки
    public int damage; //урон
    public Animator anim; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
