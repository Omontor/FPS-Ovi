using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]

    [SerializeField] public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField] AudioClip playerhitSFX;
    [SerializeField] [Range(0, 1)] float playerhitvolume = .7f;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);


    }
    void ProcessHit(DamageDealer damageDealer)
    {
        currentHealth -= damageDealer.GetDamage();

        damageDealer.Hit();
        healthBar.SetHealth(currentHealth);
        AudioSource.PlayClipAtPoint(playerhitSFX, Camera.main.transform.position, playerhitvolume);
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        //FindObjectOfType<SceneLoader>().LoadGameOver();
        
        Destroy(gameObject);
        
    }
}
