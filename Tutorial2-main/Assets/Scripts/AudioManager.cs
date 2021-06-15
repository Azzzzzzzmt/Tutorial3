using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource AS;
    public AudioSource ASMusic;

    public bool canPlay = true;

    private void Start()
    {
        
        if(PlayerPrefs.GetString("Sounds") == "True")
        {
            canPlay = true;
            ASMusic.Play();
        }
        else if (PlayerPrefs.GetString("Sounds") == "False")
        {
            canPlay = false;
            ASMusic.Stop();
        }
        else
        {
            canPlay = true;
            ASMusic.Play();
        }
    }

    public void PlayAudio(int id)
    {
        if (canPlay == true)
        {
            AS.PlayOneShot(sounds[id]);
        }
    }

    public void SetAudioState(bool state)
    {
        canPlay = state;
        if(canPlay == false)
        {
            ASMusic.Stop();
        }
        else
        {
            ASMusic.Play();
        }
    }
}
