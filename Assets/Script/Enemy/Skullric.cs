using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skullric : MonoBehaviour
{
    public GameObject gasCloud;
    public Animator gasAnim;
    public PlayerMovement playerMovement;

    void Start()
    {
        GasStarter();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void GasStarter()
    {
        if(!gasCloud.activeSelf)
        {
            gasCloud.SetActive(true);
            Invoke("GasStarter",6f);
        }
        else
        {
            gasCloud.SetActive(false);
            Invoke("GasStarter",3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("AttackArea"))
        {
            gasCloud.SetActive(false);
            Destroy(gameObject);
            playerMovement.inGas = false;
        }
    }
    

}
