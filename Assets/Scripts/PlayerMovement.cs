using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private Vector2 movement;
    private bool isGrounded = true;

    void Update() 
    {
        //jumping logic
        if (Input.GetButtonDown("Vertical") && isGrounded)
        {
            movement = new Vector2(rb.velocity.x, speed);
            rb.velocity = movement;
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float xValue = Input.GetAxis("Horizontal");
        movement = new Vector2(xValue * speed, rb.velocity.y);
        rb.velocity = movement;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") 
        {
            isGrounded = true;
        }
    }
}
