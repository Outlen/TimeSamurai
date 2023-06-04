using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public GameLose gameLose;
    public GameObject player;  
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            gameLose.Setup();
        }
    }
}
