using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerPowerUp : MonoBehaviour
{
    //public PowerUp powerUpSpot;
    // public PowerUp SpeedUpSpot;
    private bool hasShield;
    public bool shieldIsUp;
    private bool hasPowerUp;
    private bool hasMultiplier;
    private bool hasSpeedUp;
    public GameObject shield;
    public float duration;
    private SimpleCharacterControl cc;
    private PlayerController pc;
    [SerializeField] AudioClip eat;

    [SerializeField]
    private GameObject MultiplierUI, SpeedBoostUI, ShieldUI;
    [SerializeField]
    private GameObject BoostTrail;


    // Start is called before the first frame update
    void Start()
    {
        hasShield = false;
        shieldIsUp = false;
        hasSpeedUp = false;
        hasPowerUp = false;
        cc = GetComponent<SimpleCharacterControl>();
        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasShield)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                //Debug.Log("Shield activate!!");
                AudioController.Instance.PlayShieldActiveAudio();
                StartCoroutine(ShieldActive(duration));
            }
        }
        if (hasSpeedUp)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                AudioController.Instance.PlaySpeedBoostActiveAudio();
                StartCoroutine(SpeedUpActive(duration));
            }
        }
        if (hasMultiplier)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                //AudioController.Instance.PlayCheeseAudio();
                StartCoroutine(MultiplierActive(duration));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPowerUp)
        {
            if (other.tag.Equals("Shield"))
            {
                AudioController.Instance.PlayShieldBoostPickUpAudio();
                ShieldUI.SetActive(true);
                Destroy(other.gameObject);
                hasShield = true;
                hasPowerUp = true;
                //powerUpSpot.hasSpawn = false;
                //SpeedUpSpot.hasSpawn = false;
            }
            if (other.tag.Equals("SpeedUp"))
            {
                AudioController.Instance.PlaySpeedBoostPickUpAudio();
                SpeedBoostUI.SetActive(true);
                Destroy(other.gameObject);
                hasSpeedUp = true;
                hasPowerUp = true;
                //powerUpSpot.hasSpawn = false;
                //SpeedUpSpot.hasSpawn = false;
            }
            if (other.tag.Equals("Multiplier"))
            {
                AudioController.Instance.PlayCheeseAudio();
                MultiplierUI.SetActive(true);
                Destroy(other.gameObject);
                hasMultiplier = true;
                hasPowerUp = true;
            }
        }
    }

    IEnumerator ShieldActive(float duration)
    {
        shield.SetActive(true);
        shieldIsUp = true;
        ShieldUI.SetActive(false);
        yield return new WaitForSeconds(duration);
        AudioController.Instance.PlayShieldDeActiveAudio();
        shield.SetActive(false);
        hasShield = false;
        hasPowerUp = false;
        shieldIsUp = false;
    }

    IEnumerator SpeedUpActive(float duration)
    {
        cc.m_moveSpeed *= 2;
        BoostTrail.SetActive(true);
        SpeedBoostUI.SetActive(false);
        //Debug.Log("speed up");
        yield return new WaitForSeconds(duration);
        //Debug.Log("speed down");
        AudioController.Instance.PlaySpeedBoostDeActiveAudio();
        cc.m_moveSpeed /= 2;
        BoostTrail.SetActive(false);
        hasSpeedUp = false;
        hasPowerUp = false;
    }

    IEnumerator MultiplierActive(float duration)
    {
        pc.Progress++;
        MultiplierUI.SetActive(false);
        yield return new WaitForSeconds(duration);
        pc.Progress--;
        hasPowerUp = false;
        hasMultiplier = false;
    }
}
