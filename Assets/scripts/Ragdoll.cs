using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidBodies;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        
        animator = GetComponent<Animator>();

        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        animator.enabled = true;
        foreach (var rigidbody in rigidBodies)
        {
            rigidbody.isKinematic = true;
        }
        
    }
    public void ActivateRagdoll()
    {
        animator.enabled = false;
        foreach (var rigidbody in rigidBodies)
        {
            rigidbody.isKinematic = false;
        }
        
    }
    
    public void ApplyForce(Vector3 force)
    {
        var zombiehips = gameObject.transform.Find("Zombie:Hips");
        zombiehips.GetComponent<Rigidbody>().AddForce(force,ForceMode.VelocityChange);
        
    }

}

