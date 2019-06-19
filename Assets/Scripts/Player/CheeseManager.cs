using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    #region Sigleton
    public static CheeseManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    GameObject Cheese, CheeseEquipped, CheeseEquippedEnemies1, CheeseEquippedEnemies2, CheeseEquippedEnemies3;

    //Player Equipping Cheese
    public void EquippedPlayer()
    {
        Cheese.SetActive(false);
        CheeseEquipped.SetActive(true);
    }

    //Enemies Equipping Cheese
    public void EquippedEnemies1()
    {
        Cheese.SetActive(false);
        CheeseEquippedEnemies1.SetActive(true);
    }

    public void EquippedEnemies2()
    {
        Cheese.SetActive(false);
        CheeseEquippedEnemies2.SetActive(true);
    }

    public void EquippedEnemies3()
    {
        Cheese.SetActive(false);
        CheeseEquippedEnemies3.SetActive(true);
    }
}
