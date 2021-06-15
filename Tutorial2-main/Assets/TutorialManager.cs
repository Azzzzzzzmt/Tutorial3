using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text[] textGameObject;
    public GameObject[] textGameObjectsPanel;
    string[] text = new string[11];
    int howManyTimesClicked = 0;
    public GameObject tutorial;
    public GameObject shopPanel;
    public GameObject gpuPanel;
    public GameObject powerPanel;

    AudioSource audioOfText;

    private void Start()
    {
        audioOfText = GetComponent<AudioSource>();
        howManyTimesClicked = 0;
        for (int i = 0; i < 11; i++)
        {
            text[i] = textGameObject[i].text;
            textGameObject[i].text = "";
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }
    void Next()
    {
        if (howManyTimesClicked == 11) tutorial.SetActive(false);
        else
        {
            if (howManyTimesClicked > 0)
            {
                textGameObjectsPanel[howManyTimesClicked - 1].SetActive(false);
                StopAllCoroutines();
            }
            textGameObjectsPanel[howManyTimesClicked].SetActive(true);
            StartCoroutine(TextCoroutine(textGameObject[howManyTimesClicked]));
            howManyTimesClicked++;
            if (howManyTimesClicked == 6)
            {
                shopPanel.SetActive(true);
                gpuPanel.SetActive(true);
            }
            if (howManyTimesClicked == 7)
            {
                gpuPanel.SetActive(false);
                powerPanel.SetActive(true);
            }
            if (howManyTimesClicked == 8)
            {
                shopPanel.SetActive(false);
                gpuPanel.SetActive(true);
                powerPanel.SetActive(false);
            }
        }
        
    }
    IEnumerator TextCoroutine(Text TextGameObject)
    {
        foreach (char abc in text[howManyTimesClicked])
        {
            TextGameObject.text += abc;
            audioOfText.Play();
            yield return new WaitForSeconds(0.06f);
        }
    }
}


