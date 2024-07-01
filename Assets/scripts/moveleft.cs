using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour
{
    private float speed = 30;
    private playercontroller playercontrollerscript;
    private float leftbound=  -15;
    // Start is called before the first frame update
    void Start()
    {
        playercontrollerscript= GameObject.Find("player").GetComponent<playercontroller>();

    }
    // Update is called once per frame
    void Update()
    {
        // as when the object will strike with ground the gameover condition becomes trur and this statment will becomes false
        if (playercontrollerscript.gameover == false)  
        {
           transform.Translate(Vector3.right * Time.deltaTime * speed); 
        }
        if(transform.position.x < leftbound && gameObject.CompareTag("obstacle"))
        {
           Destroy(gameObject); 
        }
    }
}