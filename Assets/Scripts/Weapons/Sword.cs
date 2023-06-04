using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform attackPoint;
    
    public float attackRange; 
    public int attackDamage;

    //how many attacks per second
    public float attackRate;
    private float nextAttackTime = 0f;

    //What layer the sword deals damage to
    public LayerMask enemyLayers;

    public Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //attack cooldown
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1.0f / attackRate;     
            }
        }
    }
    
    void Attack()
    {
        //play animation
        animator.SetTrigger("Melee");

        //check for enemies inside the range of the attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //deal damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    //visualise the range of the attack
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
