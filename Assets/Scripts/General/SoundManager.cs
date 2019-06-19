using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.          
    
    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    
    public void ToogleMusic()
    {
        if (PlayerPrefs.GetInt("MutedMusic", 0) == 0)
        {
            PlayerPrefs.SetInt("MutedMusic", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MutedMusic", 0);
        }
    }

    public void ToogleSFX()
    {
        if (PlayerPrefs.GetInt("MutedSFX", 0) == 0)
        {
            PlayerPrefs.SetInt("MutedSFX", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MutedSFX", 0);
        }
    }
}