using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUandRIGManager : MonoBehaviour
{
    public List<GameObject> AllGpu; //Массив всех видеокарт
    public List<GameObject> AllRig; //Массив всех ригов
    public List<GameObject> AllBigRig; //Массив всех больших ригов

    public List<GameObject> AllGpuMain; 
    public List<GameObject> AllGpuObjects;

    

    [SerializeField] private GameObject GPUShopPrefab;
    public GameObject GPUObjectPrefab;
    [SerializeField] private GameObject GPURepairPrefab;

    [SerializeField] private GameObject GPUMainImagePrefab;

    [SerializeField] private Transform shopContent;
    public Transform objectsContent;
    [SerializeField] private Transform repairContent;
    [SerializeField] private Transform mainImageContent;

    public float Earning;
    public float EarningPerTime;

    public GameObject[] middle;
    public GameObject[] lux;
    public GameObject[] gold;
    public GameObject[] diamond;

    public List<GameObject> GTX1050;
    public List<GameObject> Graphics_1;
    public List<GameObject> XE;
    public List<GameObject> X;
    public List<GameObject> RTX_2060_Super;
    public List<GameObject> RTX_3090;
    public List<GameObject> RTX_4000;
    public List<GameObject> RX_570;
    public List<GameObject> RX_590;
    public List<GameObject> RX_5600;
    public List<GameObject> RX_6700XT;
    public List<GameObject> RX_6900;

    public List<GameObject> RTX_5000;
    public List<GameObject> RX_9000;
    public List<GameObject> Intel_Predator;


    public List<GameObject> UpgradeList;
    //public List<GameObject> BudgetaryGPU;
    //public List<GameObject> MiddleGPU;
    //public List<GameObject> LuxGPU;
    //public List<GameObject> GoldGPU;
    //public List<GameObject> DiamondGPU;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Check();
        }
    }
    /*
     0 1050V
     1 rtx3090V
     2 rx570V
     3 intelx
     4 rtx2060super
     5 rx590sapphere
     6 6700xt
     7 rtx4000
     8 intelXE
     9 rx6900
     10 rtx5000
     11 rx9000
     12 intelpredator
         */
    public void Check() //Проверяет всё и если видеокарт больше 4 то стакает их, то же и с ригами
    {
        if (AllGpu.Count != 0)
        {
            if (GTX1050.Count >= 3)
            {
               
                foreach (GameObject i in GTX1050)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                GTX1050.Clear();
                BuyGpu(UpgradeList[1]);
                Debug.Log("1");
            }
            if (Graphics_1.Count >= 3)
            {

                foreach (GameObject i in Graphics_1)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                Graphics_1.Clear();
                BuyGpu(UpgradeList[3]);
                Debug.Log("3");
            }
            if (RX_5600.Count >= 3)
            {

                foreach (GameObject i in RX_5600)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RX_5600.Clear();
                BuyGpu(UpgradeList[2]);
                Debug.Log("2");
            }
            if (RTX_3090.Count >= 3)
            {

                foreach (GameObject i in RTX_3090)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RTX_3090.Clear();
                BuyGpu(UpgradeList[4]);
                Debug.Log("4");
            }
            if (RX_570.Count >= 3)
            {

                foreach (GameObject i in RX_570)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RX_570.Clear();
                BuyGpu(UpgradeList[6]);
                Debug.Log("6");
            }
            if (X.Count >= 3)
            {

                foreach (GameObject i in X)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                X.Clear();
                BuyGpu(UpgradeList[5]);
                Debug.Log("5");
            }
            if (RTX_2060_Super.Count >= 3)
            {

                foreach (GameObject i in RTX_2060_Super)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RTX_2060_Super.Clear();
                BuyGpu(UpgradeList[7]);
                Debug.Log("7");
            }
            if (RX_590.Count >= 3)
            {

                foreach (GameObject i in RX_590)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RX_590.Clear();
                BuyGpu(UpgradeList[8]);
                Debug.Log("8");
            }
            if (RX_6700XT.Count >= 3)
            {

                foreach (GameObject i in RX_6700XT)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RX_6700XT.Clear();
                BuyGpu(UpgradeList[11]);
                Debug.Log("9");
            }
            if (RTX_4000.Count >= 3)
            {

                foreach (GameObject i in RTX_4000)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RTX_4000.Clear();
                BuyGpu(UpgradeList[10]);
                Debug.Log("10");
            }
            if (XE.Count >= 3)
            {

                foreach (GameObject i in XE)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                XE.Clear();
                BuyGpu(UpgradeList[9]);
                Debug.Log("11");
            }
            if (RX_6900.Count >= 3)
            {

                foreach (GameObject i in RX_6900)
                {
                    AllGpu.Remove(i);
                    AllGpuMain.Remove(i);
                    Destroy(i);
                }
                RX_6900.Clear();
                BuyGpu(UpgradeList[12]);
                Debug.Log("12");
            }

























            //if (RTX_5000.Count >= 3)
            //{

            //    foreach (GameObject i in RTX_5000)
            //    {
            //        AllGpu.Remove(i);
            //        AllGpuMain.Remove(i);
            //        Destroy(i);
            //    }
            //    RTX_5000.Clear();
            //    BuyGpu(UpgradeList[13]);
            //    Debug.Log("COMBINE");
            //}
            //if (RX_9000.Count >= 3)
            //{

            //    foreach (GameObject i in RX_9000)
            //    {
            //        AllGpu.Remove(i);
            //        AllGpuMain.Remove(i);
            //        Destroy(i);
            //    }
            //    RX_9000.Clear();
            //    BuyGpu(UpgradeList[14]);
            //    Debug.Log("COMBINE");
            //}

            //if (GoldGPU.Count >= 3)
            //{

            //    foreach (GameObject i in GoldGPU)
            //    {
            //        AllGpu.Remove(i);
            //        AllGpuMain.Remove(i);
            //        Destroy(i);
            //    }
            //    GoldGPU.Clear();
            //    BuyGpu(diamond[Random.Range(0, diamond.Length)]);
            //    Debug.Log("COMBINE");
            //}

            float av = 0f;
            float avpt = 0f;
            foreach (GameObject i in AllGpuMain)
            {
                if (i.GetComponent<GPUMainPanelObject>().Damage > (int)0)
                {
                    av += i.GetComponent<GPUMainPanelObject>().data.Earning;
                    avpt += i.GetComponent<GPUMainPanelObject>().data.EarningPerTime;
                }
            }
            Earning = av;
            EarningPerTime = avpt;

        }
    }

    public void BuyGpu(GameObject gpu, float damage = 100f)
    {
        if (FindObjectOfType<PowerSupply>().currentSlots < FindObjectOfType<PowerSupply>().maxSlots)
        {
            // GameObject Gpu = Instantiate(GPUObjectPrefab, objectsContent.transform);
            // Gpu.GetComponent<GPUObject>().data = gpu.GetComponent<GPU>().data;
            // AllGpuObjects.Add(Gpu);
            GameObject GpuMI = Instantiate(GPUMainImagePrefab, mainImageContent.transform);
            AllGpuMain.Add(GpuMI);
            GpuMI.GetComponent<GPUMainPanelObject>().Damage = damage;
            GpuMI.GetComponent<GPUMainPanelObject>().tear = gpu.GetComponent<GPU>().tear.ToString();
            GpuMI.GetComponent<GPUMainPanelObject>().data = gpu.GetComponent<GPU>().data;
            foreach (GameObject i in AllGpuMain)
            {
                i.GetComponent<GPUMainPanelObject>().UpdateValues();
            }
            AllGpu.Add(GpuMI);
            switch (gpu.GetComponent<GPU>().data.GP)
            {
                case "1050 TI":
                    GTX1050.Add(GpuMI);
                    break;
                case "Graphics 1":
                    Graphics_1.Add(GpuMI);
                    break;
                case "X":
                    X.Add(GpuMI);
                    break;
                case "RTX 3090":
                    RTX_3090.Add(GpuMI);
                    break;
                case "RX 570":
                    RX_570.Add(GpuMI);
                    break;
                case "RED":
                    XE.Add(GpuMI);
                    break;
                case "RTX 2060 Super":
                    RTX_2060_Super.Add(GpuMI);
                    break;
                case "RTX 4000":
                    RTX_4000.Add(GpuMI);
                    break;
                case "RX 590":
                    RX_590.Add(GpuMI);
                    break;
                case "RX 5600":
                    RX_5600.Add(GpuMI);
                    break;
                case "RX 6700XT":
                    RX_6700XT.Add(GpuMI);
                    break;
                case "RX 6900":
                    RX_6900.Add(GpuMI);
                    break;
                case "RTX 5000":
                    RTX_5000.Add(GpuMI);
                    break;
                case "RX 9000":
                    RX_9000.Add(GpuMI);
                    break;
                case "Predator":
                    Intel_Predator.Add(GpuMI);
                    break;
            }
            
            Check();
        }
        FindObjectOfType<PowerSupply>().currentSlots = AllGpuMain.Count;
        FindObjectOfType<PowerSupply>().UpdateValues();
        
    }


    public void GetAllRigs()
    {

    }
    public void GetAllGpu()
    {
       
    }
 //  GetAllBigRigs()
}
