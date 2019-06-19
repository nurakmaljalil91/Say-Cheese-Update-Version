using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    //------Amal---------
    [SerializeField]
    private RectTransform[] itemsArray;
    //public Text goldText;
    public GameObject insufficientPanel, sufficientPanel;
    public TextMeshProUGUI[] status;
    private int currentGold;
    private int middle;
    private int[] bought;
    private int used;
    public GameObject audioManager;

    void Start()
    {
        //swipe mechanic
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        itemsArray = new RectTransform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            itemsArray[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }
        bought = new int[5];
        middle = 2;
        //--------for testing-----------//
        //PlayerPrefs.SetInt("Gold", 100);
        PlayerPrefs.SetInt("Hamster 0", 1);
        //PlayerPrefs.SetInt("Hamster 1", 0);
        //PlayerPrefs.SetInt("Hamster 2", 0);
        //PlayerPrefs.SetInt("Hamster 3", 0);
        //PlayerPrefs.SetInt("Hamster 4", 0);
        //PlayerPrefs.SetInt("Use Hamster", 0);
        //--------end testing------------//
        currentGold = PlayerPrefs.GetInt("Gold");
        //goldText.text = currentGold.ToString();
        used = PlayerPrefs.GetInt("Use Hamster");
        bought = new int[5];
        bought[0] = PlayerPrefs.GetInt("Hamster 0");
        bought[1] = PlayerPrefs.GetInt("Hamster 1");
        bought[2] = PlayerPrefs.GetInt("Hamster 2");
        bought[3] = PlayerPrefs.GetInt("Hamster 3");
        bought[4] = PlayerPrefs.GetInt("Hamster 4");
       
        //rectangle = itemsArray[2].GetComponent<Rect>();
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
                {
                    //Debug.Log("Tap");
                }
            }
        }
    }

    void ResetSize()
    {
        for (int i = 0; i < itemsArray.Length; i++)
        {
            itemsArray[i].transform.localScale = new Vector2(2, 2);
        }

    }

    void SwipeRight()
    {
        RectTransform[] temp = new RectTransform[itemsArray.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = itemsArray[i];

        }
        Vector3 savePosition = temp[0].position;
        for (int i = 0; i < itemsArray.Length - 1; i++)
        {
            itemsArray[i].position = temp[i + 1].position;
        }
        itemsArray[4].position = savePosition;
        ResetSize();
        middle -= 1;
        if (middle == -1)
        {
            middle = 4;
        }
    }

    void SwipeLeft()
    {
        RectTransform[] temp = new RectTransform[itemsArray.Length];
        Vector3[] savePositions = new Vector3[itemsArray.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = itemsArray[i];

        }
        for (int i = 0; i < savePositions.Length; i++)
        {
            savePositions[i] = temp[i].position;
        }
        for (int i = 1; i < itemsArray.Length; i++)
        {
            itemsArray[i].position = savePositions[i - 1];
        }
        itemsArray[0].position = savePositions[savePositions.Length - 1];
        ResetSize();
        middle += 1;
        if (middle == 5)
        {
            middle = 0;
        }
    }

    void FocusMiddle()
    {
        if (itemsArray[middle])
        {
            itemsArray[middle].transform.localScale = new Vector2(3, 3);
        }
    }

    // for button
    public void Choose()
    {
        if (middle == 0)
        {
            Debug.Log("normal");
            if(PlayerPrefs.GetInt("Use Hamster") != 0)
            {
                status[0].text = "USED";
                PlayerPrefs.SetInt("Use Hamster", 0);

            }
            
        }
        if (middle == 1)
        {
            Debug.Log("hamtaro");
            if (bought[1] == 0)
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
                if(PlayerPrefs.GetInt("Use Hamster") != 1)
                {
                    status[1].text = "USED";
                    PlayerPrefs.SetInt("Use Hamster", 1);
                    //ResetUsed(1);
                }
            }
        }
        if (middle == 2)
        {
            Debug.Log("panda");
            if (bought[2] == 0)
            {
                if (currentGold < 300)
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
                if (PlayerPrefs.GetInt("Use Hamster") != 2)
                {
                    status[2].text = "USED";
                    PlayerPrefs.SetInt("Use Hamster", 2);
                    //ResetUsed(1);
                }
            }
        }
        if (middle == 3)
        {
            Debug.Log("villian");
            if (bought[3] == 0)
            {
                if (currentGold < 450)
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
                if (PlayerPrefs.GetInt("Use Hamster") != 3)
                {
                    status[3].text = "USED";
                    PlayerPrefs.SetInt("Use Hamster", 3);
                    //ResetUsed(1);
                }
            }
        }
        if (middle == 4)
        {
            Debug.Log("white");
            if (bought[4] == 0)
            {
                if(currentGold < 600)
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
                if (PlayerPrefs.GetInt("Use Hamster") != 4)
                {
                    status[4].text = "USED";
                    PlayerPrefs.SetInt("Use Hamster", 4);
                    //ResetUsed(1);
                }
            }
        }
      
    }

    public void ConfirmBuyButton()
    {
        if(middle == 1)
        {
            Debug.Log("Bought hamtaro");
            PlayerPrefs.SetInt("Hamster 1", 1);
            status[1].text = "USE";
            currentGold -= 100;

        }
        if (middle == 2)
        {
            PlayerPrefs.SetInt("Hamster 2", 1);
            status[2].text = "USE";
            currentGold -= 300;
        }
        if (middle == 3)
        {
            PlayerPrefs.SetInt("Hamster 3", 1);
            status[3].text = "USE";
            currentGold -= 450;
        }
        if (middle == 4)
        {
            PlayerPrefs.SetInt("Hamster 4", 1);
            status[4].text = "USE";
            currentGold -= 600;
        }
    }

    void UpdateEverythings()
    {
        currentGold = PlayerPrefs.GetInt("Gold");

        PlayerPrefs.SetInt("Gold", currentGold);
        //goldText.text = currentGold.ToString();
        bought[0] = PlayerPrefs.GetInt("Hamster 0");
        bought[1] = PlayerPrefs.GetInt("Hamster 1");
        bought[2] = PlayerPrefs.GetInt("Hamster 2");
        bought[3] = PlayerPrefs.GetInt("Hamster 3");
        bought[4] = PlayerPrefs.GetInt("Hamster 4");
        for(int i =0; i < itemsArray.Length; i++)
        {
            if(PlayerPrefs.GetInt("Hamster "+i.ToString()) == 1){
                if(PlayerPrefs.GetInt("Use Hamster") != i)
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

    // not using
    public void ResetUsed(int currentHamster)
    {
        for(int i = 0; i < itemsArray.Length; i++)
        {
            if (PlayerPrefs.GetInt("Hamster "+ i.ToString()) == 1) {

                if(PlayerPrefs.GetInt("Use Hamster") != currentHamster)
                {
                    status[i].text = "USE";
                }
            }
        }
    }

}
