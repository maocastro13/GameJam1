using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallGenerator : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    public GameObject[] rugPrefabs;
    private float spawnDelay = 0;
    private float spawnRatio = 0.37f;


    [SerializeField] float deepDistance=80;
    [SerializeField] float wallDistance=5;
    [SerializeField] float rugXRange=3;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWalls", spawnDelay, spawnRatio);
        InvokeRepeating("SpawnRugs", spawnDelay, 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnWalls()
    {
        
        //Generate leftwall
        Instantiate<GameObject>(wallPrefabs[Random.Range(0,wallPrefabs.Length)],new Vector3(-wallDistance,0,deepDistance),Quaternion.Euler(0f,-90f,0f));
        //Generate right
        Instantiate<GameObject>(wallPrefabs[Random.Range(0, wallPrefabs.Length)], new Vector3(wallDistance, 0, deepDistance+4), Quaternion.Euler(0f, 90f, 0f));
    }
    void SpawnRugs()
    {

        //Generate random rug
        Instantiate<GameObject>(rugPrefabs[Random.Range(0, rugPrefabs.Length)], new Vector3(Random.Range(-rugXRange,rugXRange), 0, deepDistance), Quaternion.Euler(0f, 0f, 0f));
    }
}
