using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlvl2 : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = .5f;
    [SerializeField] public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathvolume = .7f;
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioSource audioSource3;
    [SerializeField] AudioSource audioSource4;


    [SerializeField] AudioClip playerhitSFX;
    [SerializeField] [Range(0, 1)] float playerhitvolume = .7f;

    [Header("Projectile")]
    [SerializeField] GameObject Laser;
    [SerializeField] GameObject Laser2;
    [SerializeField] GameObject Laser3;
    [SerializeField] GameObject Laser4;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;


    void Start()
    {
        SetUpMoveBoundaries();
        currentHealth = maxHealth;
       // healthBar.SetMaxHealth(currentHealth);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Fire2();
        Fire3();
        Fire4();


    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
            audioSource1.Play();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            audioSource1.Stop();
        }
    }
    private void Fire2()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            firingCoroutine = StartCoroutine(FireContinuously2());
            audioSource2.Play();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            StopCoroutine(firingCoroutine);
            audioSource2.Stop();
        }
    }
    private void Fire3()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            firingCoroutine = StartCoroutine(FireContinuously3());
            audioSource3.Play();
        }
        if (Input.GetButtonUp("Fire3"))
        {
            StopCoroutine(firingCoroutine);
            audioSource3.Stop();
        }
    }
    private void Fire4()
    {
        if (Input.GetButtonDown("Jump"))
        {
            firingCoroutine = StartCoroutine(FireContinuously4());
            audioSource4.Play();
        }
        if (Input.GetButtonUp("Jump"))
        {
            StopCoroutine(firingCoroutine);
            audioSource4.Stop();
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(Laser, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
    IEnumerator FireContinuously2()
    {
        while (true)
        {
            GameObject laser2 = Instantiate(Laser2, transform.position, Quaternion.identity) as GameObject;
            laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
    IEnumerator FireContinuously3()
    {
        while (true)
        {
            GameObject laser3 = Instantiate(Laser3, transform.position, Quaternion.identity) as GameObject;
            laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
    IEnumerator FireContinuously4()
    {
        while (true)
        {
            GameObject laser4 = Instantiate(Laser4, transform.position, Quaternion.identity) as GameObject;
            laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPosition, newYPosition);
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
        //healthBar.SetHealth(currentHealth);
        AudioSource.PlayClipAtPoint(playerhitSFX, Camera.main.transform.position, playerhitvolume);
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        //FindObjectOfType<SceneLoader>().LoadGameOver();
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathvolume);
    }
}
