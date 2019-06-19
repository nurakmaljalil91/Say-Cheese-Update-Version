using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject Cheese, CheeseEquipped, CheeseEquippedFriendly1, CheeseEquippedFriendly2;

    private NavMeshAgent agent; // the ai nav mesh agent
    private GameObject cheese;
    private GameObject player;
    private GameObject safe;

    private float nextTurnTime;
    private Transform startTransform;
    private float _speed;

    public Animator animator;
    public float multiplyBy;
    private enum STATE
    {
        CheeseOnMap,
        PlayerHasCheese,
        HaveCheese,
        NoCheese
    };

    private STATE state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cheese = GameObject.FindGameObjectWithTag("Cheese");
        player = GameObject.FindGameObjectWithTag("Player");
        safe = GameObject.FindGameObjectWithTag("Safe");
        state = STATE.CheeseOnMap;
    }

    // Update is called once per frame
    void Update()
    {
        //All States
        if (state == STATE.CheeseOnMap)
        {
            MoveToCheese();
        }
        if (state == STATE.PlayerHasCheese)
        {
            MoveToPlayer();
        }   
        if (state == STATE.HaveCheese)
        {
            MoveToSafe();
        }
        if(state == STATE.NoCheese)
        {
            RunAway();
        }

        //Choose which state to use
        if (CheeseEquipped.activeInHierarchy == true || CheeseEquippedFriendly1.activeInHierarchy == true || CheeseEquippedFriendly2.activeInHierarchy == true)
        {
            state = STATE.HaveCheese;
        }

        if (CheeseEquipped.activeInHierarchy == false && CheeseEquippedFriendly1.activeInHierarchy == false && CheeseEquippedFriendly2.activeInHierarchy == false && Cheese.activeInHierarchy == false)
        {
            state = STATE.PlayerHasCheese;
        }

        if (Cheese.activeInHierarchy == true)
        {
            state = STATE.CheeseOnMap;
        }
        if(CheeseEquipped.activeInHierarchy == false && CheeseEquippedFriendly1.activeInHierarchy == true || CheeseEquippedFriendly2.activeInHierarchy == true && Cheese.activeInHierarchy == false)
        {
            state = STATE.NoCheese;
        }

        if(agent.speed <= 0)
        {
            animator.SetBool("isStanding", true);
        }
        else
        {
            animator.SetBool("isStanding", false);
        }
    }

    public void MoveToCheese()
    {
        agent.SetDestination(cheese.transform.position);
    }

    public void MoveToPlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    public void MoveToSafe()
    {
        agent.SetDestination(safe.transform.position);
    }

    public void RunAway()
    {
        // store the starting transform
        startTransform = transform;

        //temporarily point the object to look away from the player
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);

        //Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
        // for this if you want variable results) and store it in a new Vector3 called runTo
        Vector3 runTo = transform.position + transform.forward * multiplyBy;
        //Debug.Log("runTo = " + runTo);

        //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.

        NavMeshHit hit;    // stores the output in a variable called hit

        // 5 is the distance to check, assumes you use default for the NavMesh Layer name
        NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetNavMeshLayerFromName("Walkable"));
        //Debug.Log("hit = " + hit + " hit.position = " + hit.position);

        // just used for testing - safe to ignore
        nextTurnTime = Time.time + 5;

        // reset the transform back to our start transform
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;

        // And get it to head towards the found NavMesh position
        agent.SetDestination(hit.position);
    }

    public void CheeseLose(Vector3 hitPosition)
    {
        CheeseEquipped.SetActive(false);
        cheese.SetActive(true);
        cheese.transform.position = hitPosition;
    }

    


}
