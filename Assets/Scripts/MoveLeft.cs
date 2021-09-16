using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 30; //speed at which object(background) will move
    private PlayerController playerControllerScript; //variable to reference player controller script
    private float leftBound = -15; //variable to mark left boundary

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //finds the player object and gets the player controller component
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) //If game is not over
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); //move left
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // if obstacle position is beyond (less than) left boundary
        {
            Destroy(gameObject); //destroy obstacle 
        }

    }
}
