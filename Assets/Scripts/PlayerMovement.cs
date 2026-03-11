using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float speed = 5f;
    public GameObject swordLeft;
    public GameObject swordRight;
    private Vector2 movement;
    private bool isGrounded = true;

    void Start()
    {
        //get the player and enemy game objects
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        //ignore the boxcollider collisions for both of them so player passes through enemy
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), enemy.GetComponent<BoxCollider2D>());    
    }

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
        flipSprite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") 
        {
            isGrounded = true;
        }
    }

    private void flipSprite() 
    {
        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
            swordLeft.SetActive(true);
            swordRight.SetActive(false);
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
            swordLeft.SetActive(false);
            swordRight.SetActive(true);
        }
    }
}
