using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private float horizontal = 0;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpPower = 16;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGround;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGround)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpPower);
            }
        }

        if(Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}