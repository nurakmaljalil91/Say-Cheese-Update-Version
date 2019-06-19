using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Paused == false)
        {
            this.transform.Rotate(0, 3, 0);
        }
        //transform.RotateAround(new Vector3(0,2,0), 0.02f);
    }
}
