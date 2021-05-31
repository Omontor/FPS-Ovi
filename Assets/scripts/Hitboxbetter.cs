using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxbetter : MonoBehaviour
{

    public ZombieHealth health;
    public void OnRaycastHit(RaycastShoot raycastShoot, Vector3 direction)
    {
        health.TakeDamage(raycastShoot.gunDamage, direction);
            

        
    }
    public void OnRaycastHit(PistolRaycastShoot pistolRaycastShoot, Vector3 direction)
    {
        health.TakeDamage(pistolRaycastShoot.gunDamage, direction);



    }
    public void OnRaycastHit(AssaultRifleRaycastShoot assaultRifleRaycastShoot, Vector3 direction)
    {
        health.TakeDamage(assaultRifleRaycastShoot.gunDamage, direction);



    }
    public void OnRaycastHit(ShotgunRaycastShoot shotgunRaycastShoot, Vector3 direction)
    {
        health.TakeDamage(shotgunRaycastShoot.gunDamage, direction);



    }
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<ZombieHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
