using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text energy;
    public int defaultCurrency;
    public int currency;

    public void Start() 
    {
        currency = defaultCurrency;
    }

    public void Gain(int val)
    {
        currency += val;
        Update();
    }

    public bool Use(int val) 
    {
        if(EnoughCurrency(val)){
            currency -= val;
            return true;
        }
        else{
            return false;
        }
    }

    bool EnoughCurrency(int val)
    {
        if (val <= currency){
            return true;
        }
        else{
            return false;
        }
    }

    void Update() 
    {
        energy.text = currency.ToString();
    }

    public void test()
    {
        Debug.Log(Use(5));
    }
}
