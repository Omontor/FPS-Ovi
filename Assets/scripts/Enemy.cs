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
    Ragdoll ragdoll;
    SkinnedMeshRenderer skinnedMeshRenderer;

    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;
    


    private void Awake()
    {
        
    }

    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) +1.0f;
        skinnedMeshRenderer.material.color = Color.white * intensity;
    }
    
    
    

    public void ProcessHit(int amount)
    {
        health -= amount;
        
        AudioSource.PlayClipAtPoint(enemyhitSFX, Camera.main.transform.position, enemyhitvolume);

        if (health <= 0)
        {
            Die();
           
        }
        blinkTimer = blinkDuration;
        
    }
    
    public int GetHealth()
    {
        return health;
    }


    private void Die()
    {
        

        ragdoll.ActivateRagdoll();
        
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathvolume);
        
        gameObject.GetComponent<AIlocomotion>().enabled = false;
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        
        Destroy(gameObject, 2);
    }

   
}
