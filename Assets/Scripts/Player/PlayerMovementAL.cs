using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAL : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5.0f;
    public float dashSpeed = 15.0f;
    public float dashTime = 0.2f;
    public float dashCooldown = 2.0f;
    private float nextDash = 0.0f;
    private bool isDashing = false; 
    public Rigidbody2D rb;
    Vector2 movementDirection;
    Vector2 mousePos;
    public Camera cam;
    
    float distance = 60;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("Shoot");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Melee");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time > nextDash)
        {
            StartCoroutine(Dash());
            GetComponent<PlayerHealth>().AreaAttack(); // perform the area attack
            nextDash = Time.time + dashCooldown; // update the nextDash time
        }

    
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = movementDirection * moveSpeed;
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        // Get direction vector towards the mouse cursor
        Vector2 direction = (mousePos - rb.position).normalized;

        isDashing = true;
    
        while (Time.time < startTime + dashTime)
            {
                rb.velocity = direction * dashSpeed;
                yield return null; 
            }   
        isDashing = false;
    }

}
