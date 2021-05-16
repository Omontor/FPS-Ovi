using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject zombie;
   
    void Start()
    {
        zombie = gameObject.transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "bullet")
        {
            zombie.GetComponent<Enemy>().ProcessHit(10);
            Debug.Log("i been shot");
            
            Destroy(collider.gameObject);

        }
        
        
    }

    
}
