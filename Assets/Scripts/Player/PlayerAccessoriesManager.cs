using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccessoriesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] accessories;
    

    // Start is called before the first frame update
    void Start()
    {
        accessories = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            accessories[i] = transform.GetChild(i).gameObject;
        }
        Debug.Log(PlayerPrefs.GetInt("Use Accessory"));
        accessories[PlayerPrefs.GetInt("Use Accessory")].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
