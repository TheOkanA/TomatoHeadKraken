using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : MonoBehaviour
{
    public PlayerMovement playerMovement;

    void Start()
    {
        playerMovement.sceneNumber = 2;
    }
}
