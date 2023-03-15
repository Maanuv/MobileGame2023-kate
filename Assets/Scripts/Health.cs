using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Text Health;
    public GameObject YouLose;
    public int healthCount;
    public int defaultHealthCount;

    // Start is called before the first frame update
    public void Start()
    {
        healthCount = defaultHealthCount;
    }

    public void LoseHealth()
    {
        healthCount--;
        Health.text = healthCount.ToString();

        CheckHealthCount();
    }

    void CheckHealthCount() 
    {
        if (healthCount < 1)
        {
            YouLose.SetActive(true);
        }
    }
}
