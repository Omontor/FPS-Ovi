using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    //Rigidbody component reference
    public Rigidbody rbody;

    //prevent the bullet from deactivating if nothing is hit
    public float lifeTime;

    public void Activate(Vector3 position, Vector3 velocity)
    {
        transform.position = position;
        rbody.velocity = velocity;

        gameObject.SetActive(true);

        StartCoroutine("Decay");
    }

    private IEnumerator Decay()
    {
        yield return new WaitForSeconds(lifeTime);

        Deactivate();
    }

    public void Deactivate()
    {
        //put the bullet back in the pool
        BulletPool.main.AddToPool(this);

        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
