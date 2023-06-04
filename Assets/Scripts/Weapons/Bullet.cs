using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifespan;

    
    void OnCollisionEnter2D(Collision2D collision)
    {

        //Layer 6 is Enemies layers
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //DeSpawn bullet after some seconds if it doesn't destroy itself on collision
        //is also used to make range
        Destroy(gameObject, lifespan); 
    }
    



}
