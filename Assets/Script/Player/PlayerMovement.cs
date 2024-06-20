using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public bool isMoving;
    public PlayerHealthBar playerHealthBar;
    
    private float horizontal = 0;
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpPower = 5;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGround;
    [SerializeField] private bool canBeDamaged = true;

    public bool inGas = false;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(rb.velocity.x != 0)
        {
            isMoving = true;   
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGround)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpPower);
            }
        }

        if(Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer))
        {
            isGround = true;
            speed = 3;
        }
        else
        {
            isGround = false;
            speed = 2;
        }

        Flip();

        if(inGas)
        {
            if(canBeDamaged)
            {
                canBeDamaged = false;
                playerHealthBar.health--;
                Invoke("CanBeDamaged", 0.8f);
            }
            
        }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("HighDamage") && canBeDamaged)
        {
            canBeDamaged = false;
            playerHealthBar.health -= 5;
            Invoke("CanBeDamaged", 2f);
        }

        if(other.CompareTag("LowDamage") && canBeDamaged)
        {
            playerHealthBar.health -= 2;
        }

        if(other.CompareTag("GasDamage"))
        {
            inGas = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("GasDamage"))
        {
            inGas = false;
        }
    }

    public void CanBeDamaged()
    {
        canBeDamaged = true;
    }
}
