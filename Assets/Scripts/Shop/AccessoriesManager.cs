using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccessoriesManager : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    [SerializeField]
    private RectTransform[] accessories;
    public GameObject insufficientPanel, sufficientPanel;
    public TextMeshProUGUI[] status;

    private int currentGold;
    //public Text goldText;
    private int middle;
    private int[] bought;
    private int used;
    public GameObject audioManager;

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        accessories = new RectTransform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            accessories[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }

        bought = new int[5];
        middle = 2;
       
        currentGold = PlayerPrefs.GetInt("Gold"); // get the current gold
        PlayerPrefs.SetInt("Use Accessory", 5);
        //------------Amal------------------//
        //PlayerPrefs.SetInt("Gold", 100);
        PlayerPrefs.SetInt("Accessory 1", 0);
        PlayerPrefs.SetInt("Accessory 2", 0);
        PlayerPrefs.SetInt("Accessory 3", 0);
        PlayerPrefs.SetInt("Accessory 4", 0);
        PlayerPrefs.SetInt("Accessory 5", 0);
        //PlayerPrefs.SetInt("Top Hat", 0);
        used = PlayerPrefs.GetInt("Use Accessory");
        bought[0] = PlayerPrefs.GetInt("Accessory 1");
        bought[1] = PlayerPrefs.GetInt("Accessory 2");
        bought[2] = PlayerPrefs.GetInt("Accessory 3");
        bought[3] = PlayerPrefs.GetInt("Accessory 4");
        bought[4] = PlayerPrefs.GetInt("Accessory 5");
    }

    void Update()
    {
        SwipeMechanic();
        FocusMiddle();
        UpdateEverythings();
    }

    void SwipeMechanic()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            SwipeRight();
                            audioManager.GetComponent<AudioController>().PlaySwipeSound();
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            SwipeLeft();
                            audioManager.GetComponent<AudioController>().PlaySwipeSound();
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }
    void ResetSize()
    {
        for (int i = 0; i < accessories.Length; i++)
        {
            accessories[i].transform.localScale = new Vector2(2, 2);
        }
    }
    void SwipeRight()
    {
        RectTransform[] temp = new RectTransform[accessories.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = accessories[i];
        }

        Vector3 savePosition = temp[0].position;
        for (int i = 0; i < accessories.Length - 1; i++)
        {
            accessories[i].position = temp[i + 1].position;
        }
        accessories[4].position = savePosition;
        ResetSize();
        middle -= 1;
        if (middle == -1)
        {
            middle = 4;
        }
    }

    void SwipeLeft()
    {
        RectTransform[] temp = new RectTransform[accessories.Length];
        Vector3[] savePositions = new Vector3[accessories.Length];
        for(int i = 0;i < temp.Length; i++)
        {
            temp[i] = accessories[i];
        }
        for(int i =0;i < savePositions.Length; i++)
        {
            savePositions[i] = temp[i].position;
        }
        for(int i =1; i < accessories.Length; i++)
        {
            accessories[i].position = savePositions[i - 1];
        }
        accessories[0].position = savePositions[savePositions.Length - 1];
        ResetSize();
        middle += 1;
        if(middle == 5)
        {
            middle = 0;
        }
    }

    void FocusMiddle()
    {
        if (accessories[middle])
        {
            accessories[middle].transform.localScale = new Vector2(3, 3);
        }
    }

    //for button
    public void Choose()
    {
        if(middle == 0)
        {
            if(bought[0] == 0)
            {
                if(currentGold < 100)
                {
                    insufficientPanel.SetActive(true);
                }
                else
                {
                    sufficientPanel.SetActive(true);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Use Accessory") != 0)
                {
                    status[0].text = "USED";
                    PlayerPrefs.SetInt("Use Accessory", 0);
                }
            }
        }
     
        if (middle == 1)
        {
            if (bought[1] == 0)
            {
                if (currentGold < 200)
                {
                    insufficientPanel.SetActive(true);
                }
                else
                {
                    sufficientPanel.SetActive(true);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Use Accessory") != 1)
                {
                    status[1].text = "USED";
                    PlayerPrefs.SetInt("Use Accessory", 1);
                }
            }
        }


        if (middle == 2)
        {
            if (bought[2] == 0)
            {
                if (currentGold < 400)
                {
                    insufficientPanel.SetActive(true);
                }
                else
                {
                    sufficientPanel.SetActive(true);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Use Accessory") != 2)
                {
                    status[1].text = "USED";
                    PlayerPrefs.SetInt("Use Accessory", 2);
                }
            }
        }

        if (middle == 3)
        {
            if (bought[3] == 0)
            {
                if (currentGold < 600)
                {
                    insufficientPanel.SetActive(true);
                }
                else
                {
                    sufficientPanel.SetActive(true);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Use Accessory") != 3)
                {
                    status[1].text = "USED";
                    PlayerPrefs.SetInt("Use Accessory", 3);
                }
            }
        }


        if (middle == 4)
        {
            if (bought[4] == 0)
            {
                if (currentGold < 800)
                {
                    insufficientPanel.SetActive(true);
                }
                else
                {
                    sufficientPanel.SetActive(true);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Use Accessory") != 4)
                {
                    status[1].text = "USED";
                    PlayerPrefs.SetInt("Use Accessory", 4);
                }
            }
        }



    }

    public void ConfirmBuyButton()
    {
        if(middle == 0)
        {
            PlayerPrefs.SetInt("Accessory 1", 1);
            status[0].text = "USE";
            currentGold -= 100;
        }
        if (middle == 1)
        {
            PlayerPrefs.SetInt("Accessory 2", 1);
            status[0].text = "USE";
            currentGold -= 200;
        }
        if (middle == 2)
        {
            PlayerPrefs.SetInt("Accessory 3", 1);
            status[0].text = "USE";
            currentGold -= 400;
        }
        if (middle == 3)
        {
            PlayerPrefs.SetInt("Accessory 4", 1);
            status[0].text = "USE";
            currentGold -= 600;
        }
        if (middle == 4)
        {
            PlayerPrefs.SetInt("Accessory 5", 1);
            status[0].text = "USE";
            currentGold -= 800;
        }
    }

    void UpdateEverythings()
    {
        currentGold = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Gold", currentGold);
        //goldText.text = currentGold.ToString();
        bought[0] = PlayerPrefs.GetInt("Accessory 1");
        bought[1] = PlayerPrefs.GetInt("Accessory 2");
        bought[2] = PlayerPrefs.GetInt("Accessory 3");
        bought[3] = PlayerPrefs.GetInt("Accessory 4");
        bought[4] = PlayerPrefs.GetInt("Accessory 5");

        for(int i =0; i < accessories.Length; i++)
        {
            if(PlayerPrefs.GetInt("Accessory " + i.ToString()) == 1)
            {
                if(PlayerPrefs.GetInt("Use Accessory") != i)
                {
                    status[i].text = "USE";
                }
                else
                {
                    status[i].text = "USED";
                }
            }
        }


    }
}
