using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] int scoreValue = 10;
    
    //[SerializeField] GameObject deathVFX;
    
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathvolume = .7f;
    
    //[SerializeField] [Range(0, 1)] float enemyshootvolume = .7f;
    [SerializeField] AudioClip enemyhitSFX;
    [SerializeField] [Range(0, 1)] float enemyhitvolume = .7f;

    public GameObject zombie;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    
    

    public void ProcessHit(int amount)
    {
        health -= amount;
        
        AudioSource.PlayClipAtPoint(enemyhitSFX, Camera.main.transform.position, enemyhitvolume);

        if (health <= 0)
        {
            Die();
        }
    }
    
    public int GetHealth()
    {
        return health;
    }


    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathvolume);
    }
}
