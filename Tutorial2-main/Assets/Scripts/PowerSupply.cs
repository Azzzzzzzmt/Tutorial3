using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSupply : MonoBehaviour
{
    public Text txt;
    public int currentSlots;
    public int maxSlots;

    private void Start()
    {
        UpdateValues();
    }
    public void UpdateValues()
    {
        txt.text = $"{currentSlots}/{maxSlots}";
        if(currentSlots >= maxSlots)
        {
            txt.color = Color.red;
        }
        else
        {
            txt.color = Color.white;
        }
    }

    public void BuyPower()
    {
        if(FindObjectOfType<MoneyManager>().GetCurrentMoneyCount() > 1000){
            FindObjectOfType<MoneyManager>().RemoveMoney(1000);
            maxSlots++;
            UpdateValues();
        }
        else
        {
            FindObjectOfType<MoneyManager>().noMoney.SetActive(true);
        }
    }
}
