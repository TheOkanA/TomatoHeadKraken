using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour
{
    void Start()
    {
        Invoke("Destory3Seconds", 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void Destory3Seconds()
    {
        Destroy(gameObject);
    }
}
