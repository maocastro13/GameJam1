using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private float zBound = -15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.back * Time.deltaTime * speed,Space.World);
        if (transform.position.z < zBound || transform.position.y < -8 )
        {
            Destroy(gameObject);
        }
    }
}
