using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isSliding = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround /*&& !gameOver*/)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            /*playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);*/
        }
        /*else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && doubleJumpPowerUp && !hasDoubleJump)
        {
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump", 3, 0f);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            hasDoubleJump = true;
        }*/

        /*if(Input.GetKey(KeyCode.LeftShift) && isOnGround)
        {
            isSliding = true;

            /*doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 1.5f);
            dirtParticle.Play();
        }
        else if (doubleSpeed && speedPowerUp)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
            dirtParticle.Play();
        }*/
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            hasDoubleJump = false;
        } 
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    void OnTriggerEnter(Collider other)
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
