using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Cheese, CheesePrefabs;
    [SerializeField] private GameObject[] CheeseSpots;

    private Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        // hasSpawn = false;
        // array of points of power up
        CheeseSpots = new GameObject[transform.childCount];

        // add power ups inside the array
        for (int i = 0; i < CheeseSpots.Length; i++)
        {
            // assign the array with power ups
            CheeseSpots[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GenerateRandomPosition();
        if (Cheese.activeInHierarchy == false)
        {
            SpawnCheese();
        }
    }

    public void GenerateRandomPosition()
    {
        int rand = Random.Range(0, transform.childCount);

        randomPosition = CheeseSpots[rand].transform.position;
    }

    public void SpawnCheese()
    {
        if (CheeseEating.Instance.HasEaten == true)
        {
            Debug.Log("Spawn");
            //Cheese.transform.position = GetComponent<PlayerController>().CheeseLose(randomPosition); ;
        }
    }
}
