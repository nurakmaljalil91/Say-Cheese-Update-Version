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
                if (EnemiesController1.Instance != null)
                {
                    if (EnemiesController1.Instance.CanEat)
                    {
                        Progress += Time.deltaTime * 2;
                    }
                }
                if (EnemiesController2.Instance != null)
                {
                    if (EnemiesController2.Instance.canEat)
                    {
                        Progress += Time.deltaTime * 2;
                        
                    }
                }
                if(EnemiesController3.Instance != null)
                {
                    if (EnemiesController3.Instance.canEat)
                    {
                        Progress += Time.deltaTime * 2;
                    }
                }


            }
        }

        //Lose Condition (Remember to change the slider value)
        if (Progress >= PointsToWin)
        {
            StartCoroutine(Timer());
        }
    }

    //Timer
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.PlayerLose();
    }
}
