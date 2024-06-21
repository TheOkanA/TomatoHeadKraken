using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Door door;

    void Start()
    {
        door.sceneToLoad = 2;
        playerMovement.sceneNumber = 1;
    }
}
