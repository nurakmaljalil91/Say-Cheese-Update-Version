using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpPrefab;
    private GameObject powerUp;
    //public bool hasSpawn;
    [SerializeField] private GameObject[] powerUpSpots;

    public float duration;

    private float time;

    private Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
       // hasSpawn = false;
        // array of points of power up
        powerUpSpots = new GameObject[transform.childCount];
        // add power ups inside the array
        for (int i = 0; i < powerUpSpots.Length; i++)
        {
            // assign the array with power ups
            powerUpSpots[i] = transform.GetChild(i).gameObject;
        }

        time = duration;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateRandomPosition();
        if (!powerUp)
        {
            SpawnThePowerUp();
        }
        
    }

    public void GenerateRandomPosition()
    {
        int rand = Random.Range(0, transform.childCount);

        randomPosition = powerUpSpots[rand].transform.position;

    }

    public void SpawnThePowerUp()
    {
        time -= Time.deltaTime;

        if (time < 0 )
        {
            powerUp = Instantiate(powerUpPrefab, randomPosition, Quaternion.identity);
            time = duration;
           // hasSpawn = true;
        }
    }
}
