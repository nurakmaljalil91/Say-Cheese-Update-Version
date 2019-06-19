using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Sigleton
    public static GameManager Instance;

    private GameObject audioManager;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject Cheese, WinUI, LoseUI, player;
    [SerializeField]
    Animator TransitionAnimator;

    public bool Paused;

    public int unlockLevel;

    private int currentGold;

    private void Start()
    {
        Paused = false;
        Time.timeScale = 1;

        currentGold = PlayerPrefs.GetInt("Gold");

        TransitionAnimator.SetTrigger("IsStarting");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PausedState()
    {
        Paused = true;
        Time.timeScale = 0;
    }

    public void UnPausedState()
    {
        Paused = false;
        Time.timeScale = 1;
    }

    public void PlayerWin()
    {
        Paused = true;
        AudioController.Instance.StopInGameMusicAudio();
        AudioController.Instance.PlayWinSoundAudio();
        Time.timeScale = 0;
        WinUI.SetActive(true);

        if(PlayerPrefs.GetInt("Level") < unlockLevel)
        {
            PlayerPrefs.SetInt("Level", unlockLevel);
        }

        PlayerPrefs.SetInt("Gold", currentGold + 50);
        

    }

    public void PlayerLose()
    {
        Paused = true;
        AudioController.Instance.StopInGameMusicAudio();
        AudioController.Instance.PlayLoseSoundAudio();
        Time.timeScale = 0;
        LoseUI.SetActive(true);
    }
}
