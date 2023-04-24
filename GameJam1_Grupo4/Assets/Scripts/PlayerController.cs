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
    private float speed = 20.0f;
    private float xRange = 2.70f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isSliding = false;
    public bool gameOver = false;

    private int lifes = 2;
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
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            // Player movement left to right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }

            if (Input.GetButton("Sliding") && isOnGround)
            {
                if (!isSliding)
                {
                    // Iniciar el deslizamiento
                    isSliding = true;
                    playerAnim.SetBool("Slide", true);
                }
            }
            else
            {
                if (isSliding)
                {
                    // Terminar el deslizamiento
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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (lifes > 0)
            {
                lifesSprites[indexLifesSprites].SetActive(false);
                lifes--;
                indexLifesSprites++;
            }
            else
            {
                gameOver = true;
                Debug.Log("Game Over!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}