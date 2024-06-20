using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranapeHealth : MonoBehaviour
{
    public GameObject grape;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("AttackArea"))
        {
            Destroy(grape);
        }
    }
}
