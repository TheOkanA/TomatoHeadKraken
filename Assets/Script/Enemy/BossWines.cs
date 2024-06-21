using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossWines : MonoBehaviour
{
    public List<Transform> wines = new List<Transform>();
    public Transform selectedWines;
    public int range0;
    public GameObject[] winepoints;
    public GameObject[] returnpoints;
    public bool goUp = true;
    public int wineNumber;

    int timer = 0;

    void Awake()
    {
        StartCoroutine(BossMechanic());
        Timer();
    }

    public void Timer()
    {
        switch (timer)
        {
            case 0:
            timer++;
            goUp = true;
            Invoke("Timer", 1f);
            break;

            case 1:
            timer--;
            goUp = false;
            Invoke("Timer", 1f);
            break;
        }
    }

    void Update()
    {
        if(goUp)
        {
            WineSpawner(selectedWines, range0);
        }

        if(!goUp)
        {
            WineDestroyer(selectedWines, range0);
        }
    }

    IEnumerator BossMechanic()
    {
        int range3 = Random.Range(0, 5);
        range0 = range3;
        selectedWines = wines[range3];
        yield return new WaitForSeconds(4f);
        StartCoroutine(BossMechanic());
    }

    public void WineSpawner(Transform wine, int range2)
    {
        wine.transform.position = Vector2.MoveTowards(wine.transform.position, winepoints[range2].transform.position, 4 * Time.deltaTime);
    }

    public void WineDestroyer(Transform wine, int range2)
    {
        wine.transform.position = Vector2.MoveTowards(wine.transform.position, returnpoints[range2].transform.position, 4 * Time.deltaTime);
    }
}
