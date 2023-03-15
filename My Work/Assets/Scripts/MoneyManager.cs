using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static int money;
    public Text moneyTxt;

    void Start()
    {
        money = 20;
    }

    void Update()
    {
        moneyTxt.text = "Energy: " + money.ToString();
    }
}
