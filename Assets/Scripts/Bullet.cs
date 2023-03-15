using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Vector2 target;
    private Transform enemy;
    private Rigidbody2D rb;

    void Start()
    {
        //Sets the enemy Transform variable to the transform of a gameObject with an "Enemy" tag
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody2D>();
     

        //               --- IGNORE ALL THIS ---

        /*GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vector2 targetVelocity = enemy.GetComponent<Rigidbody2D>().velocity;

        Transform enemyTransform = enemy.GetComponent<Transform>();
        Vector2 relativePos = transform.position - enemyTransform.position;
        float theta = Vector2.Angle(relativePos, targetVelocity);

        float a = (targetVelocity.magnitude * targetVelocity.magnitude) - (speed * speed);
        float b = -2 * Mathf.Cos(theta * Mathf.Deg2Rad) * relativePos.magnitude * targetVelocity.magnitude;
        float c = relativePos.magnitude * relativePos.magnitude;
        float delta = Mathf.Sqrt((b * b) - (4 * a * c));
        float t = -(b + delta) / (2 * a);

        Vector2 enemyVector2 = enemyTransform.position;
        Vector2 prediction = enemyVector2 + (targetVelocity * t);
        target = prediction;*/

        //              --- IGNORE ALL THIS ---
    }

    void Update()
    {
        try
        {
            //Constantly receives location(transform) of enemy and sets the value to target
            target = new Vector2(enemy.position.x, enemy.position.y);

            //Moves bullet towards enemy location
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        catch (MissingReferenceException e)
        {
            Destroy(gameObject);
        }
        
    }

    //Activates when enemy collides with another object with a collider set to isTrigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroys bullet if it hits an enemy that is in range
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        //Destroys bullet if it hits an enemy that is out of range
        if (other.CompareTag("EnemyOutOfRange"))
        {
            Destroy(gameObject);
        }

        //Destroys bullet if it hits the border
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
