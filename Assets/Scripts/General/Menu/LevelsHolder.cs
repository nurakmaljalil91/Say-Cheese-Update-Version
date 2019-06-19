using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsHolder : MonoBehaviour
{
    [SerializeField]
    private Button[] levelsButtons;
    [SerializeField]
    private int currentLevel;

    void Start()
    {
        Time.timeScale = 1;
        levelsButtons = new Button[this.transform.childCount];
        for(int i = 0; i < this.transform.childCount; i++)
        {
            levelsButtons[i] = transform.GetChild(i).GetComponent<Button>();
        }

        currentLevel = PlayerPrefs.GetInt("Level") - 1;

        for(int i =0; i <= currentLevel; i++)
        {
            levelsButtons[i].interactable = true;
        }
    }
    
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("Level"));
    }
}
