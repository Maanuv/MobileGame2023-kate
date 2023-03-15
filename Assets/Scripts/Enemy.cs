using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public static float MovementSpeed = 7.5f;
    private int health;
    public int startingHealth;
    public static int numOfEnemiesInRange;
    public static int numEnemiesSpawned = 0;
    private Rigidbody2D rb;
    float timer;
    float startingTime = 0.5f;
    bool dirIsRight;


    /*private void Awake(){
        instance = this;
    }*/

    //public static Color[] colors = {Color.red, Color.yellow, Color.blue, Color.green};
    void Start()
    {
        //Sets the health of enemy when it spawns
        health = startingHealth;
        timer = startingTime;
        dirIsRight = true;

        /*int r = (numEnemiesSpawned / 5) % 4; 
        gameObject.GetComponent<Renderer>().material.color = colors[r];*/
        rb = GetComponent<Rigidbody2D>();
    }
  

    public void Update()
    {
        //Moves the enemy forward
        if(dirIsRight == false){
            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0){
            timer = startingTime;
            dirIsRight = true;
        }
        if(dirIsRight == true){
            transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
        } else if (dirIsRight == false){
            transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
        }
       
        //  gameObject.transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);

        //Destroys enemy when its health is 0
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void knockBack(){
    //     // gameObject.transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
    //     rb.AddForce(transform.left * knockBackPower);
    }

    //Activates when enemy collides with another object with a collider set to isTrigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //When enemy collides with this, it rotates down
        if (other.CompareTag("DownCheckpoint"))
        {
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }

        //When enemy collides with this, it rotates up
        if (other.CompareTag("UpCheckpoint"))
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }

        //When enemy collides with this, it rotates left
        if (other.CompareTag("LeftCheckpoint"))
        {
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }

        //When enemy collides with this, it rotates right
        if (other.CompareTag("RightCheckpoint"))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        //When enemy is hit by bullet, health reduces by 1
        if (other.CompareTag("WindBullet"))
        {
             
            health -= WindBullet.damage;
            dirIsRight = false;
        }

        //When enemy hits the border off-screen, it is destroyed
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }

        //When enemy is in range of tower, its tag is set to "Enemy" so tower can detect it
        //numOfEnemiesInRange is increased by 1
        if (other.CompareTag("TowerRadius"))
        {
            gameObject.tag = "Enemy";
            numOfEnemiesInRange++;
        }
          if (other.CompareTag("WindTurbine"))
        {
            gameObject.tag = "Enemy";
            numOfEnemiesInRange++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        //When enemy is out of range of tower, its tag is set it "EnemyOutOfRange" so tower cannot detect it
        //numOfEnemiesInRange is reduced by 1
        if (other.tag == "TowerRadius")
        {
            gameObject.tag = "EnemyOutOfRange";
            numOfEnemiesInRange--;
        }
        if (other.CompareTag("WindTurbine"))
        {
            gameObject.tag = "EnemyOutOfRange";
            numOfEnemiesInRange--;
        }
    }

    //Increases number of enemies spawned by 1 when called
    public static void enemySpawned()
    {
        numEnemiesSpawned++;
    }
    // public IEnumerator Knockback(int knockBackDuration, int knockBackPower, Transform obj){
    //     float timer = 0;
    //     while (knockBackDuration > timer){
    //         timer += Time.deltaTime;
    //         Vector2 direction = (obj.transform.position - this.transform.position).normalized;
    //         rb.AddForce(-direction * knockBackPower);
    //     }
    //     yield return 0;
    // }

}
