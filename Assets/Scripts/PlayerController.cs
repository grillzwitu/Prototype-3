using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidBody; //variable for rigid body component
    public float jumpForce = 15; //jump force variable
    public float gravityModifier; //variable to modify gravity
    public bool isOnGround = true; //variable that checks if player is on the ground
    public bool gameOver; //variable to check game over
    private Animator playerAnim; //variable to handle player animation
    public ParticleSystem explosionParticle; //variable to handle particle explosion
    public ParticleSystem dirtParticle; //variable to handle dirt particle
    public AudioClip jumpSound; //variable to handle the jump sound
    public AudioClip crashSound; //variable to handle the crash sound
    private AudioSource playerAudio; //variable to handle audio sounds from player activity

    // Start is called before the first frame update
    void Start()
    {

        playerRigidBody = GetComponent<Rigidbody>(); //gets the player rigid body component
        Physics.gravity *= gravityModifier;

        playerAnim = GetComponent<Animator>(); //gets the player animator component

        playerAudio = GetComponent<AudioSource>(); //gets the player's audio source component
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //when/if space key is pressed and player is on the ground and it is not game over
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f); // play jump sound
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //add force, to make the player jump
            isOnGround = false; //player is not on the ground
            playerAnim.SetTrigger("Jump_trig"); //trigger jump animation
            dirtParticle.Stop(); //stop throwing dirt particles
        }
    }

    //Check for collisions 
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))// when player touches the gorund
        {
            isOnGround = true;
            dirtParticle.Play(); //start throwing dirt particles
        }
        else if(collision.gameObject.CompareTag("Obstacle"))// when player touches an obstacle
        {
            playerAudio.PlayOneShot(crashSound, 1.0f); //play crash sound
            Debug.Log("Game Over");
            gameOver = true; //game over
            playerAnim.SetBool("Death_b", true); //player dies
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play(); //explosion
            dirtParticle.Stop(); //stop throwing dirt particles
        }


    }
}
