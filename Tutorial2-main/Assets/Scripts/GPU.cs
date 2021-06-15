using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GPU : MonoBehaviour
{
    public GPUData data;
    public GameObject myPrefab;
    [Header("--------------------------")]
    public Sprite img;
    public Tear tear;

    public Text desc;
    public Text name;
    public enum Tear
    {
        budgetary,
        middle,
        lux,
        gold,
        diamond
    }


    private void Start()
    {
        if (desc != null)
        {
            desc.text =
                data.Name + "\n" +
                data.GP + "\n" +
                data.Power + "W" + "\n" +
                data.Earning + "$" + "\n" +
                data.EarningPerTime + "$" + "\n";
        }
        if (name != null)
        {
            name.text = "Видеокарта "+data.Name;
        }
        transform.Find("Image").gameObject.GetComponent<Image>().sprite = img;
        transform.Find("Button").gameObject.transform.GetChild(0).GetComponent<Text>().text = data.Cost + "$";
    }

    public void Buy()
    {
        if (FindObjectOfType<PowerSupply>().currentSlots < FindObjectOfType<PowerSupply>().maxSlots)
        {
            MoneyManager MM = FindObjectOfType<MoneyManager>();
            if (MM.GetCurrentMoneyCount() >= data.Cost)
            {
                MM.RemoveMoney(data.Cost);
                FindObjectOfType<GPUandRIGManager>().BuyGpu(this.gameObject);
            }
            else
            {
                FindObjectOfType<MoneyManager>().noMoney.SetActive(true);
            }
        }
        else
        {
            FindObjectOfType<Shop>().NoPower.SetActive(true);
        }
    }
    
    
}
