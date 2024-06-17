using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject boomArea;
    public EnemyMovement enemyMovement;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("AttackArea"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            enemyMovement.moveSpeed = 0;
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("BombArea", 0.5f);
            Invoke("EnemyDestroy", 1.75f);
        }
    }

    private void BombArea()
    {
        boomArea.SetActive(true);
        spriteRenderer.enabled = false;
    }

    private void EnemyDestroy()
    {
        Destroy(gameObject);
    }
}
