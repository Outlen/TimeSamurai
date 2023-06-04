using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemy : MonoBehaviour
{
    GameObject[] enemiesJP;
    GameObject[] enemiesDS;
    Rigidbody2D[] rbsJP;
    Rigidbody2D[] rbsDS;
    // Start is called before the first frame update
    void Start()
    {
        enemiesJP = GameObject.FindGameObjectsWithTag("earlyJP");
        enemiesDS = GameObject.FindGameObjectsWithTag("dieselPunk");
        rbsJP = new Rigidbody2D[enemiesJP.Length];
        rbsDS = new Rigidbody2D[enemiesDS.Length];


        for (int i = 0; i < enemiesJP.Length; ++i) 
        {
            // get GameObject at index `i`  
            GameObject enemyJP = enemiesJP[i];
            // set rigidbody at index `i`
            rbsJP[i] = enemyJP.GetComponent<Rigidbody2D>();
        }

        for (int i = 0; i < enemiesDS.Length; ++i) 
        {
            // get GameObject at index `i`  
            GameObject enemyDS = enemiesDS[i];
            // set rigidbody at index `i`
            rbsDS[i] = enemyDS.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Space goes to Disel
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Rigidbody2D rb in rbsJP)
            {
                if(rb != null)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                }
                
            }

            foreach (Rigidbody2D rb in rbsDS)
            {
                if(rb != null)
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                }
                
            }
        }

        //Tab goes to JP
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach (Rigidbody2D rb in rbsDS)
            {
                if(rb != null)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }

            foreach (Rigidbody2D rb in rbsJP)
            {
                if(rb != null)
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                }
            }
        }
    }
}
