using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GPUData")]
public class GPUData : ScriptableObject
{
    public string Name;
    public string GP;
    public int Power;
    public int Cost;
    public float Temperature;
    public float Earning; // Доход с клика
    public float EarningPerTime; //Пассивный доход
    public Sprite sprite;
    public GameObject myPrefab;
    public string Desc
    {
        get
        {
            return Name + "\n" +
                GP + "\n" +
                Power + "W" + "\n" +
                Earning + "$" + "\n" +
                EarningPerTime + "$" + "\n" +
                Cost + "$"; ;
        }
    }
}
