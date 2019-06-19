using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProgressBar : MonoBehaviour
{
    [SerializeField]
    private GameObject CheeseEquippedEnemies1, CheeseEquippedEnemies2, CheeseEquippedEnemies3;
    [SerializeField]
    private Slider ProgressionBar;
    [SerializeField]
    private float PointsToWin;
    public float Progress;

    void Update()
    {
        ProgressionBar.value = Progress;

        //Adding Points
        if (CheeseEquippedEnemies1.activeInHierarchy == true || CheeseEquippedEnemies2.activeInHierarchy == true || CheeseEquippedEnemies3.activeInHierarchy == true)
        {
            if (GameManager.Instance.Paused == false)
            {
                Progress++;
            }
        }

        //Lose Condition (Remember to change the slider value)
        if (Progress >= PointsToWin)
        {
            GameManager.Instance.PlayerLose();
            Progress = 0;
        }
    }
}
