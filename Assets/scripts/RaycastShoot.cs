using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public int gunDamage = 25;
    public float fireRate = .25f;
    public float weaponRange = 50.0f;
    public float force = 100f;
    public Transform gunEnd;
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    public AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;
    public GameObject muzzle;
    Ray ray;
    public bool isShooting;
    public ParticleSystem muzzleflash;
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
        muzzle = GameObject.Find("muzzle");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting && Time.time >nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = new Vector3(muzzle.transform.position.x, muzzle.transform.position.y, muzzle.transform.position.z);
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if(Physics.Raycast(rayOrigin,muzzle.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
            }
           
            var hitBox = hit.collider.GetComponent<Hitboxbetter>();
            if (hitBox)
            {
                hitBox.OnRaycastHit(this, ray.direction);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (muzzle.transform.forward * weaponRange));
            }
            isShooting = false;
        }

    }
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
    public void Shoot()
    {
        isShooting = true;
        muzzleflash.Emit(1);
    }
}
