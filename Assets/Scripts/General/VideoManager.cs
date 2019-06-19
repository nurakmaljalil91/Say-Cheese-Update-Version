using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    private float VideoDuration;
    [SerializeField]
    private int NextScene;

    private void Awake()
    {
        StartCoroutine(Timer());
    }

    //Video to Next Scene Timer
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(VideoDuration);
        SceneManager.LoadScene(NextScene);
    }
}
