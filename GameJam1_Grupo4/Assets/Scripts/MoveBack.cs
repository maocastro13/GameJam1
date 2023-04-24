using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private float zBound = -15f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("PlayerSteven").GetComponent<PlayerController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed,Space.World);
        }
        
        if (transform.position.z < zBound || transform.position.y < -8 )
        {
            Destroy(gameObject);
        }
    }
}
