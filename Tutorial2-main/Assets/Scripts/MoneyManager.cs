using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
	[SerializeField]
    private int MoneyCount;


	[Header("----------OTHER----------")]
	public Text[] moneyTxt;

	public GameObject noMoney;
	private void Start()
	{
		UpdateMoney();
	}

	public void AddMoney(int count)
	{
		MoneyCount += count;
		UpdateMoney();
	}
	public void SetMoney(int count)
	{
		MoneyCount = count;
		UpdateMoney();
	}
	public void RemoveMoney(int count)
	{
		MoneyCount -= count;
		UpdateMoney();
	}
	public int GetCurrentMoneyCount()
	{
		return MoneyCount;
	}

	void GetAfkMoney()
	{

	}

	public void UpdateMoney()
	{
		foreach(Text i in moneyTxt)
		{
			i.text = MoneyCount.ToString();
		}
	}

}
