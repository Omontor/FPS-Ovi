using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]

    public int maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;

    
    [SerializeField] AudioClip playertakedamageSFX;
    
    [SerializeField] [Range(0, 1)] float playertakedamagevolume = .7f;
    public GameObject zombie;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        zombie = GameObject.Find  ("zombie") ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    public void PlayerTakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth<=amount)
        {
            Die();
        }
    }
    void OnCollisionEnter(Collision collider)
    {
        
        {
            if (collider.gameObject.CompareTag("Zombie"))
            {
                if (ZombieHealth.isAlive==true)
                
                
                {
                    PlayerTakeDamage(2);
                    Debug.Log("You got hit");
                    healthBar.SetHealth(currentHealth);
                    AudioSource.PlayClipAtPoint(playertakedamageSFX, Camera.main.transform.position, playertakedamagevolume);
                }



            }
        }
    }
    public void AddtoHealth(float amount)
    {
        currentHealth += amount;
    }

    private void Die()
    {
        //FindObjectOfType<SceneLoader>().LoadGameOver();
        Debug.Log("u dead");
        FindObjectOfType<SceneLoader>().LoadNextScene();
        //Destroy(gameObject);
        
        
    }
}
