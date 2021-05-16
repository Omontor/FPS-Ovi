using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    Ragdoll ragdoll;
    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth<=0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        ragdoll.ActivateRagdoll();
    }
}
