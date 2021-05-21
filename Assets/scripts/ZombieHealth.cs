using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField] int scoreValue = 1;
    Ragdoll ragdoll;

    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;
    public float dieForce;
    UIHealthbar healthbar;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public bool isAlive;
    public int zombieDamage = 5;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathvolume = .7f;
    public AudioSource audioSource;

    //[SerializeField] [Range(0, 1)] float enemyshootvolume = .7f;
    [SerializeField] AudioClip enemyhitSFX;
    [SerializeField] [Range(0, 1)] float enemyhitvolume = .7f;
    // Start is called before the first frame update
    void Start()
    {
        
        ragdoll = GetComponent<Ragdoll>();
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        healthbar = GetComponentInChildren<UIHealthbar>();
        foreach (var rigidBody in rigidBodies)
        {
            Hitboxbetter hitboxbetter = rigidBody.gameObject.AddComponent<Hitboxbetter>();
            hitboxbetter.health = this;
        }
        currentHealth = maxHealth;
        isAlive=true;
    }

    // Update is called once per frame
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        skinnedMeshRenderer.material.color = Color.white * intensity;

    }
    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        healthbar.SetHealthBarPercentage(currentHealth / maxHealth);
        if (currentHealth<=0.0f)
        {
            Die(direction);
        }
        blinkTimer = blinkDuration;
        AudioSource.PlayClipAtPoint(enemyhitSFX, Camera.main.transform.position, enemyhitvolume);

    }
    
    




    public void Die(Vector3 direction)
    {
        isAlive=false;
        ragdoll.ActivateRagdoll();
        direction.y = 1;
        ragdoll.ApplyForce(direction * dieForce);
        healthbar.gameObject.SetActive(false);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathvolume);
        StopNoise();
        gameObject.GetComponent<AIlocomotion>().enabled = false;
        FindObjectOfType<GameSession>().AddToScore(scoreValue);

        Destroy(gameObject, 3);

    }
    public void StopNoise()
    {
        audioSource.Stop();
    }
}
