using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]

    public Animator bloodSplatterFX;
    public int maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    
    
    [SerializeField] AudioClip playertakedamageSFX;
    
    [SerializeField] [Range(0, 1)] float playertakedamagevolume = .7f;
    public GameObject zombie;
    
    // Start is called before the first frame update
    void Start()
    {
        bloodSplatterFX = GameObject.Find("blooddamage").GetComponent<Animator>();
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

        if(currentHealth>95)
        {
            bloodSplatterFX.SetBool("health100", true);
        }
        if(currentHealth<90)
        {
            bloodSplatterFX.SetBool("damage90", true);
        }
        if(currentHealth<66)
        {
            bloodSplatterFX.SetBool("damage66", true);
        }
        if(currentHealth<33)
        {
            bloodSplatterFX.SetBool("damage33",true);
        }
        
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
