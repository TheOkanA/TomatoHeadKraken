using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    GameObject player;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (!player)
            return;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance <10)
        {
            timer += Time.deltaTime;
            timer = 0;
            if (a == false)
            {
             StartCoroutine(timert());
             a = true;
            }

        }
    }

            bool a = false;
    IEnumerator timert()
    {
        Shoot();
        yield return new WaitForSeconds(1.5f);
        a = false;
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
