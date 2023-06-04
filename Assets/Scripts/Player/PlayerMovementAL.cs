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
    bool facingRight = true;
    
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

        if (mousePos.x > transform.position.x && !facingRight)
        {
            flip();
        }
        else if (mousePos.x < transform.position.x && facingRight)
        {
            flip();
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Move", true);
        }

        else 
        {
            animator.SetBool("Move", false);
        }


        if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time > nextDash)
        {
            StartCoroutine(Dash());
            GetComponent<PlayerHealth>().AreaAttack(); // perform the area attack
            nextDash = Time.time + dashCooldown; // update the nextDash time
        }

    
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
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
