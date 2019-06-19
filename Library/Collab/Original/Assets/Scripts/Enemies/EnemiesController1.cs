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
    private GameObject Cheese, CheeseEquipped;

    public bool CanEat;

    private void Start()
    {
        CanEat = false;
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
            Debug.Log("Inside safe");
        }
    }
}
