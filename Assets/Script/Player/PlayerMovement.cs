using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public bool isMoving;
    public bool isDeath = false;
    public PlayerHealthBar playerHealthBar;
    public int scene;

    private float horizontal = 0;
    public float speed = 3;
    [SerializeField] private float jumpPower = 5;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGround;
    [SerializeField] private bool canBeDamaged = true;

    public bool inGas = false;

    public GameObject life1, life2, life3;
    public int sceneNumber = 0;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (rb.velocity.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isDeath", isDeath);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGround)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpPower);
            }
        }

        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        Flip();

        if (inGas)
        {
            if (canBeDamaged)
            {
                canBeDamaged = false;
                playerHealthBar.health--;
                LifeCheck();
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
        if (other.CompareTag("HighDamage") && canBeDamaged)
        {
            canBeDamaged = false;
            playerHealthBar.health -= 5;
            LifeCheck();
            Invoke("CanBeDamaged", 2f);
        }

        if (other.CompareTag("LowDamage") && canBeDamaged)
        {
            playerHealthBar.health -= 2;
            LifeCheck();
        }

        if (other.CompareTag("GasDamage"))
        {
            inGas = true;
        }

        if (other.CompareTag("Wine"))
        {
            playerHealthBar.health -= 1;
            Invoke("CanBeDamaged", 1f);
            LifeCheck();
        }

        if (other.CompareTag("Spike"))
        {
            playerHealthBar.health -= 100;
            LifeCheck();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GasDamage"))
        {
            inGas = false;
        }
    }

    public void CanBeDamaged()
    {
        canBeDamaged = true;
    }

    public void LifeCheck()
    {
        if (playerHealthBar.health <= 0)
        {
            print("You lose");
            isDeath = true;
            Invoke("LoadScene", 0.8f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

}

