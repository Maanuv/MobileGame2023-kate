using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sunPrefab;
    public float timer;
    public float startTime;
    public float startY;
    public GameObject particles;
    Shop shop;

    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Energy").GetComponent<Shop>();
        timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            Instantiate(sunPrefab, new Vector3(transform.position.x, transform.position.y + startY, transform.position.z), Quaternion.identity);

            timer = startTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Sun")) {
            Destroy(GameObject.FindGameObjectWithTag("Sun"));
            shop.Gain(3);
            Instantiate(particles, transform.position, Quaternion.identity);
            
        }

    }
}
