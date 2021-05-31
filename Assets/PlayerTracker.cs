using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    GameObject player;
    
    public Vector3 offset = new Vector3(-7, 12);
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position+offset;
    }
}
