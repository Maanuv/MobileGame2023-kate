using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float timer;
    public float startingTime;
    public float rate;
    public int count;
    
    void Start()
    {
        //Sets the starting time of timer
        timer = startingTime;

        //Sets rate of spawn to 1.0
        rate = 1.0f;

        //Sets count to 0
        count = 0;
    }

    void Update()
    {
        //Timer minus 1 spread out using Time.deltaTime
        timer -= rate * Time.deltaTime;

        //When timer is 0, enemy spawns and timer starts again
        if (timer <= 0)
        {
            //Spawn enemy
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            //Increases number of enemies spawned by 1 by calling this method
            Enemy.enemySpawned();

            //Reset Timer
            timer = startingTime;

            //Increases count by 1
            count++;
        }

        //When count is 5 and rate of spawn is less than 2.5, rate is increased and count is set to 0 again
        //Rate must be less than 2.5 as precondition since that is the maximum rate to want. We don't want enemies to spawn faster than this rate
        //After 5 enemies spawn, rate increases
        if (count == 5 && rate <= 2.5)
        {
            rate += 0.5f;
            count = 0;
        }
    }
}
