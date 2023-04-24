using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallGenerator : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    public GameObject[] rugPrefabs;
    private float spawnDelay = 0;
    private float spawnRatio = 0.37f;

    //deep and width distance of the hall
    private float deepDistance=25;
    private float wallDistance=5;


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
        GameObject randomRug=rugPrefabs[Random.Range(0, rugPrefabs.Length)];
        Instantiate<GameObject>(randomRug, new Vector3(-1.86f, 0,deepDistance), randomRug.transform.rotation);
    }
}
