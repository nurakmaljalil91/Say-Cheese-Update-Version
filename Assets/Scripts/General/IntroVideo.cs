﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Video Played", 1);
    }

}
