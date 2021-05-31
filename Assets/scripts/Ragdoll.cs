using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidBodies;
    Animator animator;
    Collider[] hitcolliders;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        hitcolliders = GetComponentsInChildren<Collider>();
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
        foreach(var collider in hitcolliders)
        {
            Collider.Destroy(collider);
        }
    }
    
    public void ApplyForce(Vector3 vector3)
    {
        
        var zombiehips = gameObject.transform.Find("Zombie:Hips");
        zombiehips.GetComponent<Rigidbody>().AddForce(vector3,ForceMode.VelocityChange);
        
    }

}

