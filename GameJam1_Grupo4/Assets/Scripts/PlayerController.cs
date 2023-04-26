using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public GameObject[] lifesSprites;

    private float horizontalInput;
    private float horizontalSpeed = 20.0f;
    private float xRange = 4f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isSliding = false;
    public bool gameOver = false;

    private int lifes = 3;
    private int indexLifesSprites = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (!gameOver)
        {
            // Check for left and right bounds
            if (transform.position.x <= -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x >= xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            // Player movement left to right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput);

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround && !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }

            if ((Input.GetButton("Sliding") || Input.GetKeyDown(KeyCode.DownArrow)) && isOnGround)
            {
                if (!isSliding)
                {
                    // Starts Sliding
                    isSliding = true;
                    playerAnim.SetBool("Slide", true);
                }
            }
            else
            {
                if (isSliding)
                {
                    // Ends Sliding
                    isSliding = false;
                    playerAnim.SetBool("Slide", false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colission with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Disable isTrigger from Obstacle object. Player cannot get damaged by the same object twice.
            other.enabled = false;

            //If the player is sliding while triggers Enter with an Air object, it doesn't lose a life
            if (other.gameObject.name.Contains("ObstacleAir") && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            {
                Debug.Log("Avoided: " + other.gameObject.name);

            }
            else {
                Debug.Log("Damaged by: " + other.gameObject.name);
                
                lifes--;
                lifesSprites[indexLifesSprites].SetActive(false);
                indexLifesSprites++;
            }
        }
        if (lifes <= 0)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}