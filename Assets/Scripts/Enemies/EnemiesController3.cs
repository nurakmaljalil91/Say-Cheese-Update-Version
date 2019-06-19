using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesController3 : MonoBehaviour
{
    #region Sigleton
    public static EnemiesController3 Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public bool canEat;
    public bool insideHouse;

    [SerializeField]
    private GameObject Cheese;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CheeseDetectScript>())
        {
            AudioController.Instance.PlayCheeseAudio();
            CheeseManager.Instance.EquippedEnemies3();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Safe")
        {
            canEat = true;
            //Debug.Log("Inside safe");
            insideHouse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Safe"))
        {
            canEat = false;
            insideHouse = false;
        }
    }
}
