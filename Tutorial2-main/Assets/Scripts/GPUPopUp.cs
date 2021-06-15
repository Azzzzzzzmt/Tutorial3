using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GPUPopUp : MonoBehaviour, IPointerClickHandler
{
    public GameObject GpuPopUp;
    public enum Type
    {
        shop,
        objects,
        repair
    }
    public Type type;
    private void Start()
    {
        switch (type)
        {
            case Type.shop:
                GpuPopUp = FindObjectOfType<Shop>().ShopPopUp;
                break;
            case Type.objects:
                GpuPopUp = FindObjectOfType<Shop>().ObjectsPopUp;
                break;
            case Type.repair:
                GpuPopUp = FindObjectOfType<Shop>().RepairPopUp;
                break;
        }
        
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
       
        switch (type)
        {
            case Type.shop:
                GpuPopUp.SetActive(true);
                FindObjectOfType<Shop>().ShopImg.sprite = GetComponent<GPU>().data.sprite;
                FindObjectOfType<Shop>().ShopTxt.text = GetComponent<GPU>().desc.text;
                FindObjectOfType<Shop>().ShopName.text = GetComponent<GPU>().name.text;
                FindObjectOfType<Shop>().ShopBtn.onClick.RemoveAllListeners();
                FindObjectOfType<Shop>().ShopBtn.onClick.AddListener(GetComponent<GPU>().Buy);
                break;
            //case Type.objects:
            //    GetComponent<GPUObject>().UpdateValues(GetComponent<GPUObject>().damage);
            //    FindObjectOfType<Shop>().ObjectsImg.sprite = GetComponent<GPUObject>().data.sprite;
            //    FindObjectOfType<Shop>().ObjectsTxt.text = GetComponent<GPUObject>().data.Desc;
            //    FindObjectOfType<Shop>().ObjectsBtnSell.onClick.RemoveAllListeners();
            //    FindObjectOfType<Shop>().ObjectsBtnSell.onClick.AddListener(GetComponent<GPUObject>().Sell);
            //    FindObjectOfType<Shop>().ObjectsBtnWork.onClick.RemoveAllListeners();
            //    FindObjectOfType<Shop>().ObjectsBtnWork.onClick.AddListener(GetComponent<GPUObject>().Work);
            //    if(GetComponent<GPUObject>().damage <= 99f)
            //    {
            //        FindObjectOfType<Shop>().ObjectsBtnWork.interactable = false;
            //    }
            //    else
            //    {
            //        FindObjectOfType<Shop>().ObjectsBtnWork.interactable = true;
            //    }
            //    break;
            //case Type.repair:

            //    break;
        }
    }
    public GPUObject GPUObj;
    Shop shop;
    public void ObjectInspect(GPUObject GpuObj)
    {
        shop = FindObjectOfType<Shop>();
        GpuPopUp.SetActive(true);
        GPUObj = GpuObj;

    }
    private void Update()
    {
        if (GPUObj != null)
        {
            GPUObj.UpdateValues(GPUObj.damage);
            if (GPUObj.damage < 35f) { shop.ObjectsDamage.color = Color.red; }
            if (GPUObj.damage >= 35f && GPUObj.damage <= 60f) { FindObjectOfType<Shop>().ObjectsDamage.color = Color.yellow; }
            if (GPUObj.damage > 60f) { shop.ObjectsDamage.color = Color.green; }
            shop.ObjectsImg.sprite = GPUObj.data.sprite;
            shop.ObjectsTxt.text = GPUObj.data.Desc;
            shop.ObjectsDamage.text = GPUObj.damage.ToString("0") + "%";
            shop.ObjectsName.text = "Видеокарта " + GPUObj.data.Name;
            shop.ObjectsBtnSell.onClick.RemoveAllListeners();
            shop.ObjectsBtnSell.onClick.AddListener(GPUObj.Sell);
            shop.ObjectsBtnWork.onClick.RemoveAllListeners();
            shop.ObjectsBtnWork.onClick.AddListener(GPUObj.Work);
            if (GPUObj.damage <= 99f)
            {
                shop.ObjectsBtnWork.interactable = false;
            }
            else
            {
                shop.ObjectsBtnWork.interactable = true;
            }
        }
    }
}
