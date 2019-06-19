using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] itemsArray;

    private int middle;

    // Start is called before the first frame update
    void Start()
    {
        itemsArray = new RectTransform[transform.childCount];

        for(int i = 0; i < transform.childCount; i++){
            itemsArray[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }

        middle = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        SwipeRight();
        SwipeLeft();
        FocusMiddle();
        Debug.Log(middle);
    }

    void ResetSize(){
      for(int i =0; i < itemsArray.Length; i++)
        {
            itemsArray[i].transform.localScale = new Vector2(1, 1);
        }
    
    }
    
    void SwipeRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
           
            Debug.Log("work");
            RectTransform[] temp = new RectTransform[itemsArray.Length];
            
            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = itemsArray[i];
                Debug.Log(temp[i].position);
            }

            Vector3 savePosition = temp[0].position;



            Debug.Log("------------");

            for (int i = 0; i < itemsArray.Length - 1; i++)
            {
                itemsArray[i].position = temp[i + 1].position;
            }


            itemsArray[4].position = savePosition;

            for(int i = 0; i < itemsArray.Length; i++)
            {
                Debug.Log(itemsArray[i].position);
            }

            ResetSize();
            middle -= 1;
            if(middle == -1)
            {
                middle = 4;
            }
        }   

    }

    void SwipeLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("yeah work!");
            RectTransform[] temp = new RectTransform[itemsArray.Length];
            Vector3[] savePositions = new Vector3[itemsArray.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = itemsArray[i];
                Debug.Log(temp[i].position);
            }

            for(int i = 0; i < savePositions.Length; i++)
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

            if(middle == 5)
            {
                middle = 0;
            }
        }
    }



    void FocusMiddle()
    {
        if (itemsArray[middle])
        {
            itemsArray[middle].transform.localScale = new Vector2(2, 2);
        }
    }

    void ResetArray()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //itemsArray[i] = transform.GetChild(i).gameObject;
        }
    }
}
