using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatbackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startpos;
    private float repeatwidth;
    void Start()
    {
        startpos=transform.position;
        // to reset the position when the object has moved a distance equal to half of its collider width
        repeatwidth=GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
       // Check if the object has moved beyond a certain x-coordinate
    //    if object has moved 60 ahead of x position
        if (transform.position.x > startpos.x + repeatwidth) 
        {
            // Reset the position to the starting position
            transform.position = startpos;
        } 
    }
}
