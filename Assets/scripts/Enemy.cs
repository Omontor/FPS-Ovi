using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    
    //[SerializeField] GameObject deathVFX;
    
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathvolume = .7f;
    
    //[SerializeField] [Range(0, 1)] float enemyshootvolume = .7f;
    [SerializeField] AudioClip enemyhitSFX;
    [SerializeField] [Range(0, 1)] float enemyhitvolume = .7f;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
        Debug.Log("i been shot");

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        AudioSource.PlayClipAtPoint(enemyhitSFX, Camera.main.transform.position, enemyhitvolume);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathvolume);
    }
}
