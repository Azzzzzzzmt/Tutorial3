using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    //GPU
    public List<string> GPUNameSaveData;
    public List<float> GPUDamageSaveData;
    public int GpuInMainCount;
    //OBJECTS
    public List<string> GPUNameSaveDataOBJ;
    public List<float> GPUDamageSaveDataOBJ;
    public int GpuInObjectsCount;

    public GameObject GpuContentMain;
    public GameObject GpuContentObjects;

    public GameObject[] Gpus;
    public GameObject[] GpusOBJ;

    public float delay;
    private void Start()
    {
        Load();
        StartCoroutine(SaveIE());
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    IEnumerator SaveIE()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Save();
        }
    }
    public void Save()
    {

        //GPU
        string sounds = PlayerPrefs.GetString("Sounds");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Sounds", sounds);
        PlayerPrefs.SetString("FirstStart", "Completed");
        GPUNameSaveData.Clear();
        GPUNameSaveDataOBJ.Clear();
        GPUDamageSaveDataOBJ.Clear();
        GPUDamageSaveData.Clear();
        PlayerPrefs.SetInt("PowerMaxSlots",FindObjectOfType<PowerSupply>().maxSlots);
        PlayerPrefs.SetInt("PowerCurrentSlots",FindObjectOfType<PowerSupply>().currentSlots);
        for(int i = 0; i<GpuContentMain.transform.childCount;i++)
        {
            GPUNameSaveData.Add(GpuContentMain.transform.GetChild(i).GetComponent<GPUMainPanelObject>().data.GP);
            GPUDamageSaveData.Add(GpuContentMain.transform.GetChild(i).GetComponent<GPUMainPanelObject>().Damage);
            
        }
        PlayerPrefs.SetInt("gpumaincount", GpuContentMain.transform.childCount);
        for (int i = 0; i < GPUNameSaveData.Count; i++)
        {
            PlayerPrefs.SetString("Name_" + i, GPUNameSaveData[i]);
        }
        for (int i = 0; i < GPUDamageSaveData.Count; i++)
        {
            PlayerPrefs.SetFloat("Damage_" + i, GPUDamageSaveData[i]);
        }
        //OBJECTS
        for (int i = 0; i < GpuContentObjects.transform.childCount; i++)
        {
            GPUNameSaveDataOBJ.Add(GpuContentObjects.transform.GetChild(i).GetComponent<GPUObject>().data.GP);
            GPUDamageSaveDataOBJ.Add(GpuContentObjects.transform.GetChild(i).GetComponent<GPUObject>().damage);

        }
        PlayerPrefs.SetInt("gpuobjectscount", GpuContentObjects.transform.childCount);
        for (int i = 0; i < GPUNameSaveDataOBJ.Count; i++)
        {
            PlayerPrefs.SetString("OBJName_" + i, GPUNameSaveDataOBJ[i]);
        }
        for (int i = 0; i < GPUDamageSaveDataOBJ.Count; i++)
        {
            PlayerPrefs.SetFloat("OBJDamage_" + i, GPUDamageSaveDataOBJ[i]);
        }
        //ENERGY
        PlayerPrefs.SetFloat("Energy",FindObjectOfType<EnergyManager>().energyCount);
        //Money
        PlayerPrefs.SetInt("Money", FindObjectOfType<MoneyManager>().GetCurrentMoneyCount());
        PlayerPrefs.SetString("FirstTime", "");
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            //POWER
            FindObjectOfType<PowerSupply>().maxSlots = 9999999;
            
            //GPU
            int countMain = PlayerPrefs.GetInt("gpumaincount");
            for (int i = 0; i < countMain; i++)
            {
                GPUNameSaveData.Add(PlayerPrefs.GetString("Name_" + i));
                GPUDamageSaveData.Add(PlayerPrefs.GetFloat("Damage_" + i));
            }
            for (int i = 0; i < GPUNameSaveData.Count; i++)
            {
                foreach (GameObject j in Gpus)
                {
                    if (j.GetComponent<GPU>().data.GP == GPUNameSaveData[i])
                    {
                        FindObjectOfType<GPUandRIGManager>().BuyGpu(j, GPUDamageSaveData[i]);
                        break;
                    }
                }
            }
            //OBJECTS
            int countObjects = PlayerPrefs.GetInt("gpuobjectscount");
            for (int i = 0; i < countObjects; i++)
            {
                GPUNameSaveDataOBJ.Add(PlayerPrefs.GetString("OBJName_" + i));
                GPUDamageSaveDataOBJ.Add(PlayerPrefs.GetFloat("OBJDamage_" + i));
            }
            for (int i = 0; i < GPUNameSaveDataOBJ.Count; i++)
            {
                foreach (GameObject j in Gpus)
                {
                    if (j.GetComponent<GPU>().data.GP == GPUNameSaveDataOBJ[i])
                    {
                        GameObject Gpu = Instantiate(FindObjectOfType<GPUandRIGManager>().GPUObjectPrefab, GpuContentObjects.transform);
                        Gpu.GetComponent<GPUObject>().data = j.GetComponent<GPU>().data;
                        Gpu.GetComponent<GPUObject>().UpdateValues(GPUDamageSaveDataOBJ[i]);

                        FindObjectOfType<GPUandRIGManager>().AllGpuObjects.Add(Gpu);
                        break;
                    }
                }

            }


            //ENERGY
            FindObjectOfType<EnergyManager>().energyCount = PlayerPrefs.GetFloat("Energy");
            FindObjectOfType<EnergyManager>().UpdateValues();
            //Money
            FindObjectOfType<MoneyManager>().SetMoney(PlayerPrefs.GetInt("Money"));
            //POWER
            FindObjectOfType<PowerSupply>().maxSlots = PlayerPrefs.GetInt("PowerMaxSlots");
            FindObjectOfType<PowerSupply>().UpdateValues();
        }
    }

    public void DeleteAllProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
