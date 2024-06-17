using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnim : MonoBehaviour
{

    void Start()
    {
        Invoke("BoomTime", 1.25f);
    }

    public void BoomTime()
    {
        Destroy(gameObject);
    }
}
