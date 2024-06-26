using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    public int bosshealth = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("AttackArea"))
        {
            bosshealth--;
            if(bosshealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(0);
            }  
        }
    }
}
