using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Door door;

    void Start()
    {
        door.sceneToLoad = 3;
        playerMovement.sceneNumber = 2;
    }
}
