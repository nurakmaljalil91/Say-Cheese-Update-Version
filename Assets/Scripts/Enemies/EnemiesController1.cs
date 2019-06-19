using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesController1 : MonoBehaviour
{
    #region Sigleton
    public static EnemiesController1 Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    //private GameObject Cheese, CheeseEquipped;

    public bool CanEat;
    //public GameObject houseOpaque, houseTranparent;
    [SerializeField]
    private bool insideHouse;

    private void Start()
    {
        CanEat = false;
    }

    private void Update()
    {
        if (!insideHouse)
        {
            MakeHouseOpaque();
        }
        else
        {
            MakeHouseTransparent();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CheeseDetectScript>())
        {
            AudioController.Instance.PlayCheeseAudio();
            CheeseManager.Instance.EquippedEnemies1();
        }
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Safe")
        {
            CanEat = true;
            //Debug.Log("Inside safe");
            insideHouse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Safe"))
        {
            CanEat = false;
            insideHouse = false;
        }
    }

    void MakeHouseTransparent()
    {
        //houseTranparent.SetActive(true);
        //houseOpaque.SetActive(false);
    }

    void MakeHouseOpaque()
    {
       // houseOpaque.SetActive(true);
       // houseTranparent.SetActive(false);
    }

}
