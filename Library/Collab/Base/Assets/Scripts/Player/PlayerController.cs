using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Sigleton
    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject Cheese,CheeseEquipped, CheeseEquippedEnemies1, CheeseEquippedEnemies2, CheeseEquippedEnemies3;
    [SerializeField]
    private Slider ProgressionBar;
    [SerializeField]
    private float PointsToWin;
    
    public float Progress;
    private Transform PlayerPosition;

    public GameObject cheesePrefab;

    private GameObject cheese;

    private void Start()
    {
        ProgressionBar.value = 0;
    
    }

    private void Update()
    {
        ProgressionBar.value = Progress;

        //Adding Points
        if (CheeseEquipped.activeInHierarchy == true)
        {
            if (GameManager.Instance.Paused == false)
            {
                Progress++;
            }
        }

        //Win Condition (Remember to change the slider value)
        if (Progress >= PointsToWin)
        {
            GameManager.Instance.PlayerWin();
        }

        //Testing Button
        if (Input.GetButtonDown("Unequip"))
        {
            CheeseEquipped.SetActive(false);
            //Instantiate(Cheese, transform.position, Quaternion.identity);
        }
    }

    //Player/Enemies Collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy 1")
        {
            if (CheeseEquipped.activeInHierarchy == false && CheeseEquippedEnemies1.activeInHierarchy == true)
            {
                //CheeseWaitTImer();
                CheeseEquipped.SetActive(true);
                CheeseEquippedEnemies1.SetActive(false);
            }
        }

        if (other.tag == "Enemy 2")
        {
            if (CheeseEquipped.activeInHierarchy == false && CheeseEquippedEnemies2.activeInHierarchy == true)
            {
                //CheeseWaitTImer();
                CheeseEquipped.SetActive(true);
                CheeseEquippedEnemies2.SetActive(false);
            }
        }

        if (other.tag == "Enemy 3")
        {
            if (CheeseEquipped.activeInHierarchy == false && CheeseEquippedEnemies3.activeInHierarchy == true)
            {
                //CheeseWaitTImer();
                CheeseEquipped.SetActive(true);
                CheeseEquippedEnemies3.SetActive(false);
            }
        }

        if (other.tag == "Cheese")
        {
            CheeseManager.Instance.EquippedPlayer();
        }

        //Parenting Cheese
        /*
        if (other.tag == "Cheese")
        {
            Cheese.transform.parent = this.transform;
            Cheese.transform.position = this.transform.position;
        }
        */
    }

    //Timer
    IEnumerator CheeseWaitTImer()
    {
        yield return new WaitForSeconds(2f);
    }

    public void CheeseLose(Vector3 hitPosition){
        if(CheeseEquipped.activeSelf){
            CheeseEquipped.SetActive(false);
            cheese = Instantiate(cheesePrefab, hitPosition, Quaternion.identity);
            Debug.Log("acrive");
        }
    }

    public bool CheckCheeseEquip(){
        return CheeseEquipped.activeSelf;
    }
}
