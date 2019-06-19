using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombprefab;
    private GameObject bomb;
    [SerializeField]private GameObject[] bombSpots;
    public float duration;
    private float time;
    private Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        bombSpots = new GameObject[transform.childCount];

        for(int i = 0; i < bombSpots.Length; i++){
            bombSpots[i] = transform.GetChild(i).gameObject;
        }

        time = duration;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateRandomPosition();
        if(!bomb){
            SpawnTheBomb();
        }
    }

    public void GenerateRandomPosition(){
        int rand = Random.Range(0, transform.childCount);

        randomPosition = bombSpots[rand].transform.position;
    }

    public void SpawnTheBomb(){
        time -= Time.deltaTime;

        if(time < 0){
            bomb = Instantiate(bombprefab, randomPosition, Quaternion.identity);
            time = duration;
        }
    }
}
