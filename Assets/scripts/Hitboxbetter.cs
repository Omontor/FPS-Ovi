using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxbetter : MonoBehaviour
{

    public ZombieHealth health;
    public void OnRaycastHit(RaycastShoot raycastShoot, Vector3 direction)
    {
        if (ZombieHealth.isAlive)
        {
            health.TakeDamage(raycastShoot.gunDamage, direction);
            FindObjectOfType<Player>().AddtoHealth(1);
            FindObjectOfType<HealthBar>().SetHealth(FindObjectOfType<Player>().currentHealth);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
