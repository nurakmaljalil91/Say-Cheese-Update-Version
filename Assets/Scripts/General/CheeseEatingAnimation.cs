using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseEatingAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cheeseState;
    public int currentState;
    public bool once = false;
    private float delay =1;
    // Start is called before the first frame update
    void Start()
    {
        cheeseState = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            cheeseState[i] = transform.GetChild(i).gameObject;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        

        if (currentState == 1)
        {
            StartCoroutine(InitialState());
        }
        if (currentState == 2)
        {
            StartCoroutine(SecondState());
        }
        if (currentState == 3)
        {
            StartCoroutine(ThirdState());
        }
        if (currentState == 4)
        {
            StartCoroutine(FourthState());
        }
      
    }

    IEnumerator InitialState()
    {
        cheeseState[0].SetActive(true);
        cheeseState[1].SetActive(true);
        cheeseState[2].SetActive(true);
        cheeseState[3].SetActive(true);
        yield return new WaitForSeconds(delay);
        cheeseState[0].SetActive(false);
        currentState = 2;
    }

    IEnumerator SecondState()
    {
        cheeseState[1].SetActive(true);
        yield return new WaitForSeconds(delay);
        cheeseState[1].SetActive(false);
        currentState = 3;
    }

    IEnumerator ThirdState()
    {
        cheeseState[2].SetActive(true);
        yield return new WaitForSeconds(delay);
        cheeseState[2].SetActive(false);
        currentState = 4;
    }

    IEnumerator FourthState()
    {
        cheeseState[3].SetActive(true);
        yield return new WaitForSeconds(delay);
        cheeseState[3].SetActive(false);
        currentState = 0;
        once = false;

    }

    public void StartAnimation(bool isTrue)
    {
        if (isTrue)
        {
            if (!once)
            {
                currentState = 1;
                once = true;
            }
            
        }
    }




}
