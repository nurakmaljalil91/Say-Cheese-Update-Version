using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBgm : MonoBehaviour
{

    private AudioSource BGM;
    private bool pause;
    
    // Start is called before the first frame update
    void Start()
    {
        BGM = GetComponent<AudioSource>();
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBgm(AudioClip music)
    {
        if (!pause)
        {
            BGM.Stop();
            BGM.clip = music;
            BGM.Play();
        }
       
    }

    public void PauseBgm()
    {
        BGM.Pause();
        pause = true;
    }

    public void PlayBgm()
    {
        BGM.UnPause();
        pause = false;
    }
}
