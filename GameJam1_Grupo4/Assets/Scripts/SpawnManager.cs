using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float zSpawnPos = 15;
    public float xRangePos = 4.3f;
    private float spawnDelay = 1;
    private float spawnRatio = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnRatio);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        int spawnerIndex = Random.Range(0, 4);
        Vector3 SpawnPos;
        if (spawnerIndex == 0)
        {
            SpawnPos = new Vector3(Random.Range(-xRangePos, xRangePos-3), 2, zSpawnPos);

        }
        else 
        {
            SpawnPos = new Vector3(Random.Range(-xRangePos, xRangePos-4),0, zSpawnPos);

        }

        Instantiate<GameObject>(obstaclePrefabs[spawnerIndex], SpawnPos, transform.rotation);
    }
}
