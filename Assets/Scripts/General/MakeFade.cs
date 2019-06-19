using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFade : MonoBehaviour
{

    public bool isFade;
    public Material opaque;
    public Material fade;
    // Start is called before the first frame update
    void Start()
    {
        isFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade)
        {
            GetComponent<Renderer>().material = fade;
        }
        else
        {
            GetComponent<Renderer>().material = opaque;
        }

        isFade = false;
    }
}
