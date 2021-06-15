using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public Slider slider;
    public Text txt;

    public float energyCount;
    public float maxEnergy;

    public GameObject lossEnergyPanel;
    
    public void UpdateValues()
    {
        slider.maxValue = maxEnergy;
        slider.value = energyCount;
        txt.text = $"{energyCount} / {maxEnergy}";
        if(energyCount <= 0)
        {
            lossEnergyPanel.SetActive(true);
        }
    }

    public void RemoveEnergy(float count)
    {
        if (energyCount > 0f)
        {
            energyCount -= count;
        }
        UpdateValues();
    }

    public void BuyEnergy()
    {
        
            if (FindObjectOfType<MoneyManager>().GetCurrentMoneyCount() >= 100)
            {
                energyCount += 100;
                FindObjectOfType<MoneyManager>().RemoveMoney(100);
                UpdateValues();
            }
        else
        {
            FindObjectOfType<MoneyManager>().noMoney.SetActive(true);
        }
        
    }
}
