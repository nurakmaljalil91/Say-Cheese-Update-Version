using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseEatingEnemies : MonoBehaviour
{

   

    [SerializeField]
    private float TimeToEat, StartTimeToEat;
    [SerializeField]
    private GameObject Cheese, Door;

    public Animator DoorAnimator,vilianAnimator;

    public bool HasEaten;

    private void Start()
    {
        TimeToEat = StartTimeToEat;
        HasEaten = false;
    }

    private void Update()
    {
        if (TimeToEat <= 0)
        {
            AudioController.Instance.PlayEatingDeActiveAudio();
            //GreyAnimator.SetTrigger("StopEating");
            vilianAnimator.SetBool("isEating", false);
            TimeToEat = StartTimeToEat;
            Cheese.SetActive(true);
            HasEaten = true;
            AudioController.Instance.PlayDoorCloseAudio();
            DoorAnimator.SetTrigger("IsEnding");
            gameObject.SetActive(false);
        }
        else
        {
            HasEaten = false;
        }
    }

    // Only able to eat in House
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Safe")
        {
            TimeToEat -= Time.deltaTime;
            Debug.Log("Should stay");
        }
    }

    // Play Eating audio
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Safe")
        {
            StartCoroutine(Timer());
            //GreyAnimator.SetTrigger("IsEating");
            vilianAnimator.SetBool("isEating", true);
            AudioController.Instance.PlayEatingActiveAudio();
        }
    }

    // Door Close Timer
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        Door.SetActive(true);
        AudioController.Instance.PlayDoorCloseAudio();
        DoorAnimator.SetTrigger("IsStarting");
    }
}
