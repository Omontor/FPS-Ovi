using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    BulletPool bPool;
    public Transform fpCamera;
    public Transform firePoint;

    //gun settings
    public float firePower = 10f;

    //state
    public bool isShooting;
    public float fireSpeed;
    public float fireTimer;
    [SerializeField] AudioClip shootbangsoundsfx;
    [SerializeField] [Range(0, 1)] float shootbangsoundsfxvolume = .7f;

    void Start()
    {
        bPool = BulletPool.main;
        
    }

    public void Shoot()
    {
        //bullet velocity
        Vector3 bulletVelocity = fpCamera.forward * firePower;

        //pick (spawn) bullet from bulletpool
        bPool.PickFromPool(firePoint.position, bulletVelocity);
        AudioSource.PlayClipAtPoint(shootbangsoundsfx, Camera.main.transform.position, shootbangsoundsfxvolume);
    }

    public void PullTrigger()
    {
        //fullauto-
        if (fireSpeed > 0) isShooting = true;

        else Shoot();
    }

    public void ReleaseTrigger()
    {
        //stop shooting
        isShooting = false;
        //set cooldown timer to zero to immediately shoot on next press
        fireTimer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            if (fireTimer > 0) fireTimer -= Time.deltaTime;

            else
            {
                fireTimer = fireSpeed;
                Shoot();
            }
        }
    }
}
