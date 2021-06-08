using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIlocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    NavMeshAgent agent;
    Animator animator;
    float timer = 0.0f;
    public bool isAttacking = false;
    public AudioClip attack;
    public float attackVolume;
    public bool isTracking;
    private float turnSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isTracking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTracking)
        {
            timer -= Time.deltaTime;
            float distance = Vector3.Distance(agent.nextPosition, playerTransform.position);
            if (timer < 0.0f)
            {
                float sqDistance = (playerTransform.position - agent.destination).sqrMagnitude;
                if (sqDistance > maxDistance * maxDistance)
                {
                    FaceTarget();
                    agent.destination = playerTransform.position;
                }
                timer = maxTime;
            }

            animator.SetFloat("Speed", agent.velocity.magnitude);
            if (distance <= maxDistance)
            {
                
                animator.SetBool("isAttacking", true);
                AudioSource.PlayClipAtPoint(attack, agent.transform.position, attackVolume);
            }
            
            if (distance > maxDistance)
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }
    private void FaceTarget()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
