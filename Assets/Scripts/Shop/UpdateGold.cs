using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateGold : MonoBehaviour
{
    public Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = PlayerPrefs.GetInt("Gold").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = PlayerPrefs.GetInt("Gold").ToString();
    }
}
