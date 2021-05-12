using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    //Singleton reference
    public static BulletPool main;

    //settings
    public GameObject bulletPrefab;
    public int poolSize = 100;

    // Can also use Queue<Bullet>
    private List<Bullet> availableBullets;


    // Start is called before the first frame update
    private void Awake()
    {
        //Initialize Singleton
        main = this;
    }
    
    void Start()
    {
        availableBullets = new List<Bullet>();

        for (int i=0; i<poolSize; i++)
        {
            //Instantiate bullet clone
            Bullet b = Instantiate(bulletPrefab, transform).GetComponent<Bullet>();
            b.gameObject.SetActive(false);

            // add it to the pool
            availableBullets.Add(b);
        }
        
    }

    public void PickFromPool(Vector3 position, Vector3 velocity)
    {
        //prevent errors
        if (availableBullets.Count < 1) return;

        //activate the bullet
        availableBullets[0].Activate(position, velocity);

        //pop it from the list
        availableBullets.RemoveAt(0);

    }
    
    public void AddToPool(Bullet bullet)
    {
        //add bullet back to the pool
        if (!availableBullets.Contains(bullet)) availableBullets.Add(bullet);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
