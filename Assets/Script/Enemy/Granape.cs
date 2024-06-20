using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Granape : MonoBehaviour
{
    public Transform playerTransform; 
    public GameObject grapePrefab;
    public Transform shootPoint;
    public int grapeSpeed;
    public bool fireCooldown = true;
    public bool agroOn = false;
    void Update()
    {
        if(transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector3( 1, 1, 1 );
        }

        if(transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3( -1, 1, 1 );
        }

        if(agroOn)
        {
            if(fireCooldown)
            {
                ShootGape();
            }
        }
        
    }

    public void ShootGape()
    {
        fireCooldown = false;
        var bullet = Instantiate(grapePrefab, shootPoint.position, quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shootPoint.up * grapeSpeed; 
        Invoke("CooldownReturner", 2f);
    }

    public void CooldownReturner()
    {
        fireCooldown = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            agroOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            agroOn = false;
        }
    }
}
