using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

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
    private GameObject Cheese, CheeseEquipped, CheeseEquippedEnemies1, CheeseEquippedEnemies2, CheeseEquippedEnemies3, ShieldEquipped;
    [SerializeField]
    private Slider ProgressionBar;
    [SerializeField]
    private float PointsToWin;
    [SerializeField]
    private GameObject enemy1, enemy2, enemy3;
    public float Progress;
    [SerializeField]
    private float[] enemiesSpeeds;
    private Transform PlayerPosition;
    private GameObject cheese;

    public GameObject houseOpaque, houseTranparent;
    public Renderer model;
    public Texture[] textures;
    private float TimeBetweenHit;
    private bool WasHit;
    private bool insideHouse;

    public GameObject cheeseEatingAnimation;

    private void Start()
    {
        ProgressionBar.value = 0;
        WasHit = false;
        cheese = GameObject.FindGameObjectWithTag("Cheese");
        model.material.mainTexture = textures[PlayerPrefs.GetInt("Use Hamster")];
        enemiesSpeeds = new float[3];
        enemiesSpeeds[0] = enemy1.GetComponent<NavMeshAgent>().speed;
        enemiesSpeeds[1] = enemy2.GetComponent<NavMeshAgent>().speed;
        enemiesSpeeds[2] = enemy3.GetComponent<NavMeshAgent>().speed;
    }

    private void Update()
    {
        ProgressionBar.value = Progress;
        
        // Win Condition (Remember to change the slider value)
        if (Progress >= PointsToWin)
        {
            StartCoroutine(Timer());
        }

        if (WasHit == true)
        {
            StartCoroutine(HitTimer());
        }

        // Taking Delay
        if (WasHit == true)
        {
            TimeBetweenHit -= Time.deltaTime;
        }

        if (TimeBetweenHit <= 0)
        {
            WasHit = false;
        }

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
        if (collision.gameObject.GetComponent<EnemiesController1>())
        {
            if (CheeseEquipped.activeInHierarchy == false && CheeseEquippedEnemies1.activeInHierarchy == true && WasHit == false)
            {
                AudioController.Instance.PlayBumpAudio();
                CheeseEquipped.SetActive(true);
                CheeseEquippedEnemies1.SetActive(false);
                TimeBetweenHit = 3;
                WasHit = true;
            }
            else if (CheeseEquipped.activeInHierarchy == true && CheeseEquippedEnemies1.activeInHierarchy == false && WasHit == false && ShieldEquipped.activeInHierarchy == false)
            {
                AudioController.Instance.PlayBumpAudio();
                CheeseEquipped.SetActive(false);
                CheeseEquippedEnemies1.SetActive(true);
                TimeBetweenHit = 3;
                WasHit = true;
            }
        }

        if (collision.gameObject.GetComponent<EnemiesController2>())
        {
            if (CheeseEquipped.activeInHierarchy == false && CheeseEquippedEnemies2.activeInHierarchy == true && WasHit == false)
            {
                AudioController.Instance.PlayBumpAudio();
                CheeseEquipped.SetActive(true);
                CheeseEquippedEnemies2.SetActive(false);
                TimeBetweenHit = 3;
                WasHit = true;
            }
            else if (CheeseEquipped.activeInHierarchy == true && CheeseEquippedEnemies2.activeInHierarchy == false && WasHit == false && ShieldEquipped.activeInHierarchy == false)
            {
                AudioController.Instance.PlayBumpAudio();
                CheeseEquipped.SetActive(false);
                CheeseEquippedEnemies2.SetActive(true);
                TimeBetweenHit = 3;
                WasHit = true;
            }
        }

        if (collision.gameObject.GetComponent<EnemiesController3>())
        {
            if (CheeseEquipped.activeInHierarchy == false && CheeseEquippedEnemies3.activeInHierarchy == true && WasHit == false)
            {
                AudioController.Instance.PlayBumpAudio();
                CheeseEquipped.SetActive(true);
                CheeseEquippedEnemies3.SetActive(false);
                TimeBetweenHit = 3;
                WasHit = true;
            }
            else if(CheeseEquipped.activeInHierarchy == true && CheeseEquippedEnemies3.activeInHierarchy == false && WasHit == false && ShieldEquipped.activeInHierarchy == false)
            {
                AudioController.Instance.PlayBumpAudio();
                CheeseEquipped.SetActive(false);
                CheeseEquippedEnemies3.SetActive(true);
                TimeBetweenHit = 3;
                WasHit = true;
            }

        }

        if (collision.gameObject.GetComponent<CheeseDetectScript>())
        {
            AudioController.Instance.PlayCheeseAudio();
            CheeseManager.Instance.EquippedPlayer();
        }
    }


    // Only able to eat in House
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Safe")
        {
            if (CheeseEquipped.activeInHierarchy == true)
            {
                if (GameManager.Instance.Paused == false)
                {
                    Progress += 0.01f;
                    insideHouse = true;
                    CheeseEquipped.transform.GetChild(0).GetComponent<MeshRenderer>().gameObject.SetActive(false);
                    cheeseEatingAnimation.GetComponent<CheeseEatingAnimation>().StartAnimation(true);
                    
                   

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Safe")
        {
            insideHouse = false;
            CheeseEquipped.transform.GetChild(0).GetComponent<MeshRenderer>().gameObject.SetActive(true);
         

        }
    }

    public void CheeseLose(Vector3 hitPosition)
    {
        if (CheeseEquipped.activeSelf)
        {
            CheeseEquipped.SetActive(false);
            cheese.SetActive(true);
            cheese.transform.position = hitPosition;
        }
    }

   
    // Win Timer
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.PlayerWin();
    }

    // Hit Timer
    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(2f);
        WasHit = false;
    }

    void MakeHouseTransparent()
    {
        houseTranparent.SetActive(true);
        houseOpaque.SetActive(false);
    }

    void MakeHouseOpaque()
    {
        houseOpaque.SetActive(true);
        houseTranparent.SetActive(false);
    }

    IEnumerator EnemyIsStopping()
    {
        enemy1.GetComponent<NavMeshAgent>().speed = 0;
        enemy2.GetComponent<NavMeshAgent>().speed = 0;
        enemy3.GetComponent<NavMeshAgent>().speed = 0;
        yield return new WaitForSeconds(4);
        enemy1.GetComponent<NavMeshAgent>().speed = enemiesSpeeds[0];
        enemy2.GetComponent<NavMeshAgent>().speed = enemiesSpeeds[1];
        enemy3.GetComponent<NavMeshAgent>().speed = enemiesSpeeds[2];
    }
}
