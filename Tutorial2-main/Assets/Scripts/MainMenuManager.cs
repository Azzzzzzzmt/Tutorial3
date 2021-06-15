using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject objectPanel;
    public GameObject settingsPanel;
    public Image[] imgs;
    public Color ActiveColor;
    public GameObject objectPopUp;
    public Transform objContent;
    public GameObject noneText;
    public void CloseAll()
    {
        objectPopUp.SetActive(false);
        foreach (Transform i in objContent.transform)
        {
            i.GetComponent<GPUPopUp>().GPUObj = null;
        }
        shopPanel.SetActive(false);
        objectPanel.SetActive(false);
        settingsPanel.SetActive(false);
        foreach (Image i in imgs)
        {
            i.color = Color.white;
        }
    }
    public void ClosePopUp()
    {
        objectPopUp.SetActive(false);
        foreach (Transform i in objContent.transform)
        {
            i.GetComponent<GPUPopUp>().GPUObj = null;
        }
    }
    public void ActiveImage(Image img)
    {
        img.color = ActiveColor;
    }
    public void ShopOpenPanel()
    {
        shopPanel.SetActive(true);
    }
    public void ObjectListOpenPanel()
    {
        objectPanel.SetActive(true);
        if(FindObjectOfType<GPUandRIGManager>().AllGpuObjects.Count <= 0)
        {
            noneText.SetActive(true);
        }
        else
        {
            noneText.SetActive(false);
        }
    }
  
    public void SettingsPanel()
    {
        if(settingsPanel.activeSelf == true)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }
    }
    public void ShopClosePanel()
    {
        shopPanel.SetActive(false);
    }
    public void ObjectListClosePanel()
    {
        objectPanel.SetActive(false);
    }
    public void NewGame()
    {

    }
    public void LoadGame()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}
