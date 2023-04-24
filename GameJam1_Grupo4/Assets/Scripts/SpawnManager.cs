using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float zSpawnPos = 15;


    // Each type of obstacle has its own right bound because of size and pivot location
    private float xLeftBound = -4.6f;
    private float xAirRightBound = 3.2f;
    private float xMidRightBound = 3.2f;
    private float xBigRightBound = 2.0f;

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
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Vector3 SpawnPos;
        if (obstacleToSpawn.name.Contains("ObstacleAir"))
        {
            //Debug.Log("AirObs");

            SpawnPos = new Vector3(Random.Range(xLeftBound, xAirRightBound),Random.Range(0.8f, 1.5f), zSpawnPos);

        }
        else if (obstacleToSpawn.name.Contains("ObstacleMid"))
        {
            //Debug.Log("MidObs");

            SpawnPos = new Vector3(Random.Range(xLeftBound, xMidRightBound), 0, zSpawnPos);

        }
        else 
        //(obstacleToSpawn.name.Contains("Big"))
        {

            //Debug.Log("BigObs");
            SpawnPos = new Vector3(Random.Range(xLeftBound, xBigRightBound), 0, zSpawnPos);

        }

        Instantiate<GameObject>(obstacleToSpawn, SpawnPos, obstacleToSpawn.transform.rotation);
    }
}
