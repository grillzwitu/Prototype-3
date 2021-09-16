using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos; //variable to set start position
    private float repeatWidth; //variable to check position to repeat background

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; //assign start position to initial position of the object
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //assign repeatWidth to half the size of the background on x-axis
    }

    // Update is called once per frame
    void Update()
    {
        //check position of the object and reset to the start position at a target position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
