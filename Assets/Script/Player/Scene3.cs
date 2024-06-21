using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3 : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Door door;

    void Start()
    {
        door.sceneToLoad = 4;
        playerMovement.sceneNumber = 3;
    }
}
