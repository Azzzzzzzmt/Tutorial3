using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwitch : MonoBehaviour
{
    public GameObject onImg;
    public GameObject offImg;

    public bool isOn;

    private void Start()
    {
        if (PlayerPrefs.GetString("Sounds") == "True")
        {
            isOn = true;
            onImg.SetActive(true);
            offImg.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Sounds") == "False")
        {
            isOn = false;
            onImg.SetActive(false);
            offImg.SetActive(true);
        }
        else
        {
            isOn = true;
            onImg.SetActive(true);
            offImg.SetActive(false);
        }
    }
    public void SetState()
    {
        isOn = !isOn;
        if (isOn)
        {
            PlayerPrefs.SetString("Sounds", "True");
            onImg.SetActive(true);
            offImg.SetActive(false);
        }
        else{
            PlayerPrefs.SetString("Sounds", "False");
            onImg.SetActive(false);
            offImg.SetActive(true);
        }
        FindObjectOfType<AudioManager>().SetAudioState(isOn);
    }
}
