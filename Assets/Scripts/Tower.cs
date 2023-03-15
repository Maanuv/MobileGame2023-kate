using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float timer;
    public float startingTime;

    void Start()
    {
        //Sets the starting time of timer
        timer = startingTime;
    }

    void Update()
    {
        //Timer minus 1 spread out using Time.deltaTime
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }

        //When timer is 0 and there is at least 1 enemy in range, bullet is instantiated and timer resets
        if (timer <= 0 && Enemy.numOfEnemiesInRange > 0)
        {   
            //Instantiate bullet
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            //Reset timer
            timer = startingTime;
        }
    }
}
