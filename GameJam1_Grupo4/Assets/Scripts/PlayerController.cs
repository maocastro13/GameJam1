using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    private float horizontalInput;
    private float speed = 20.0f;
    private float xRange = 2.30f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isSliding = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
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

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround /*&& !gameOver*/)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetBool("isJumping", true);
           // dirtParticle.Stop();
           // playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        /*else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && doubleJumpPowerUp && !hasDoubleJump)
        {
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump", 3, 0f);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            hasDoubleJump = true;
        }*/

        if(Input.GetButton("Sliding") && isOnGround)
        {
            if (!isSliding)
            {
                // Iniciar el deslizamiento
                isSliding = true;
                playerAnim.SetBool("Sliding", true);
                /*playerRb.useGravity = false;
                playerRb.transform.localScale = new Vector3(playerRb.transform.localScale.x, playerRb.transform.localScale.y / 2f, playerRb.transform.localScale.z);
                playerRb.useGravity = true;
                playerRb.centerOfMass = new Vector3(playerRb.centerOfMass.x, playerRb.centerOfMass.y / 2f, playerRb.centerOfMass.z);*/
    
                /*doubleSpeed = true;
                playerAnim.SetFloat("Speed_Multiplier", 1.5f);
                dirtParticle.Play();*/
            }
            
        }
        else
        {
            if (isSliding)
            {
                // Terminar el deslizamiento
                isSliding = false;
                playerAnim.SetBool("Sliding", false);
                /*playerRb.useGravity = false;
                playerRb.transform.localScale = new Vector3(playerRb.transform.localScale.x, playerRb.transform.localScale.y * 2f, playerRb.transform.localScale.z);
                playerRb.useGravity = true;
                playerRb.centerOfMass = new Vector3(playerRb.centerOfMass.x, playerRb.centerOfMass.y * 2f, playerRb.centerOfMass.z);/*

                /*doubleSpeed = false;
                playerAnim.SetFloat("Speed_Multiplier", 1.5f);
                dirtParticle.Play();*/
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.SetBool("isJumping",false);
            //playerAnim.SetBool("Sliding",false);
            /*dirtParticle.Play();
            hasDoubleJump = false;*/
        } 
        /*else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }*/
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp") && !isPowerUpActive)
        {
            MyPowerUp powerUp = other.GetComponent<MyPowerUp>();

            if (powerUp != null)
            {
                if (powerUp.powerUpType == MyPowerUp.PowerUpType.Speed)
                {
                    StartCoroutine(ActivateSpeedPowerUp());

                    GameObject speedPowerUp = GameObject.Find("SpeedBonus(Clone)");
                    Destroy(speedPowerUp);
                }
                else if (powerUp.powerUpType == MyPowerUp.PowerUpType.DoubleJump)
                {
                    StartCoroutine(ActivateDoubleJumpPowerUp());

                    GameObject jumpPowerUp = GameObject.Find("DoubleJumpBonus(Clone)");
                    Destroy(jumpPowerUp);
                }
                else if (powerUp.powerUpType == MyPowerUp.PowerUpType.Heal)
                {
                    StartCoroutine(ActivateHealPowerUp());

                    GameObject healPowerUp = GameObject.Find("HealthBonus(Clone)");
                    Destroy(healPowerUp);
                }
                Destroy(other);
            }
        }
    }*/
}
