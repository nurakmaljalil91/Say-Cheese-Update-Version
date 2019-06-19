using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Sigleton
    public static GameManager Instance;
    //private AudioManager audioManager;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject Cheese, CheeseWaypoint, WinUI, LoseUI, player;
    public bool Paused;

    private void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

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
        //audioManager.PlaySound("Win");
        Debug.Log("Test");
        //Player Win
        //Time.timeScale = 0f;

        WinUI.SetActive(true);

    }

    public void PlayerLose()
    {
        //audioManager.PlaySound("Lose");
        //Enemies Win
        //Time.timeScale = 0f;

        LoseUI.SetActive(true);
    }
}
