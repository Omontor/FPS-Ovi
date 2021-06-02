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
        direction = (this.transform.position - pistolRaycastShoot.transform.position) / (this.transform.position - pistolRaycastShoot.transform.position).magnitude;
        health.TakeDamage(pistolRaycastShoot.gunDamage, direction);
        Debug.Log(direction);
       
        this.transform.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);


    }
    public void OnRaycastHit(AssaultRifleRaycastShoot assaultRifleRaycastShoot, Vector3 direction)
    {
        direction = (this.transform.position - assaultRifleRaycastShoot.transform.position) / (this.transform.position - assaultRifleRaycastShoot.transform.position).magnitude;
        health.TakeDamage(assaultRifleRaycastShoot.gunDamage, direction);
        this.transform.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);


    }
    public void OnRaycastHit(ShotgunRaycastShoot shotgunRaycastShoot, Vector3 direction)
    {
        direction = (this.transform.position - shotgunRaycastShoot.transform.position) / (this.transform.position - shotgunRaycastShoot.transform.position).magnitude;
        health.TakeDamage(shotgunRaycastShoot.gunDamage, direction);
        this.transform.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);


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
