using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public int areaDamage = 100; // damage for the area attack
    public float attackRadius = 3f; // radius of the area attack

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void AreaAttack()
    {
        // Find all colliders within the radius
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        // For each collider...
        foreach (Collider2D enemy in hitEnemies)
        {
            // Check if it's an enemy
            if (enemy.gameObject.CompareTag("Enemies"))
            {
                // Get the enemy script and damage the enemy
                enemy.GetComponent<Enemy>().TakeDamage(areaDamage);
            }
        }
    }
}
