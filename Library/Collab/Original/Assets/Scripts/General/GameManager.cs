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
    private GameObject Cheese, CheeseWaypoint, WinUI, LoseUI, player;

    [SerializeField]
    private AudioClip winSound, loseSound;
    public bool Paused, gameOver;

    private void Start()
    {


        Time.timeScale = 1;

        player = GameObject.FindGameObjectWithTag("Player");


    }
    private void Update()
    {
        if (!player.GetComponent<PlayerController>().CheckCheeseEquip())
        {
            CheeseWaypoint.SetActive(true);
        }
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

        WinUI.SetActive(true);
        SoundManager.instance.RandomizeSfx(winSound);
        gameOver = true;

    }

    public void PlayerLose()
    {

        LoseUI.SetActive(true);
        SoundManager.instance.RandomizeSfx(loseSound);
    }


}
