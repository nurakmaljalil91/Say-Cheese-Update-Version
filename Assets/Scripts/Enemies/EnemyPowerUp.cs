using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPowerUp : MonoBehaviour
{
    private bool hasShield;
    private bool hasSpeedUp;
    public bool shieldIsUp;
    private bool hasPowerUp;
    public GameObject sheildEquip;
    public float duration;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hasShield = false;
        hasSpeedUp = false;
        hasPowerUp = false;
        shieldIsUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 5.0f);
        foreach(Collider hit in colliders)
        {
            if (hit.transform.tag.Equals("Bomb"))
            {
                StartCoroutine(ShieldActive(duration));
            }
        }
        if (hasSpeedUp)
        {
            StartCoroutine(SpeedUpActive(duration));
        }
    }
    
    
    IEnumerator ShieldActive(float duration)
    {
        sheildEquip.SetActive(true);
        shieldIsUp = true;
        yield return new WaitForSeconds(duration);
        sheildEquip.SetActive(false);
        hasShield = false;
        hasPowerUp = false;
        shieldIsUp = false;
    }

    IEnumerator SpeedUpActive(float duration)
    {
        agent.speed *= 2;
        yield return new WaitForSeconds(duration);
        agent.speed /= 2;
        hasSpeedUp = false;
        hasPowerUp = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPowerUp)
        {
            if (other.tag.Equals("Shield"))
            {
                Destroy(other.gameObject);
                hasShield = true;
                hasPowerUp = true;
            }
            if (other.tag.Equals("SpeedUp"))
            {
                Destroy(other.gameObject);
                hasSpeedUp = true;
                hasPowerUp = true;
            }
            
        }
    }
}
