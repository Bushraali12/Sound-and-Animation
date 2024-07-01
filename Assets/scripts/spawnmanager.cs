using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacleprefab;
    private Vector3 spawnpos= new Vector3(87,0,10);
    private float startdelay=4;
    private float repeatdelay=4;
    private playercontroller playercontrollerscript;
    void Start()
    {
       InvokeRepeating("spawnobstacles" ,startdelay,repeatdelay);
       playercontrollerscript= GameObject.Find("player").GetComponent<playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void spawnobstacles()
    {
        if (playercontrollerscript.gameover == false)  
        {
            Instantiate(obstacleprefab,spawnpos,obstacleprefab.transform.rotation);
        }
    }
}
