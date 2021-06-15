using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEarning : MonoBehaviour
{
    public float delay;

    public GPUandRIGManager GARM;
    public MoneyManager MM;
    void Start()
    {
        StartCoroutine(earning());
        GARM = FindObjectOfType<GPUandRIGManager>();
        MM = FindObjectOfType<MoneyManager>();
    }

    IEnumerator earning()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            MM.AddMoney((int)GARM.EarningPerTime);
        }
    }
}
