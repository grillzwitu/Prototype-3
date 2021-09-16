using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab; //variable for spawned objects
    private Vector3 spawnPos = new Vector3(35, 0, 0); //Position for newly spawned objects
    private float startDelay = 2; //Time duration before first spawn
    private float repeatRate = 2; //Time duration before next spawn
    private PlayerController playerControllerScript; //variable to reference player controller script

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn method
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) //Check if game is not over
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
