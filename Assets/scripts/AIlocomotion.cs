﻿using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float distance = Vector3.Distance(agent.nextPosition, playerTransform.position);
        if(timer < 0.0f)
        {
            float sqDistance = (playerTransform.position - agent.destination).sqrMagnitude;
            if(sqDistance > maxDistance * maxDistance)
            {
                agent.destination = playerTransform.position;
            }
            timer = maxTime;
        }
        
        animator.SetFloat("Speed", agent.velocity.magnitude);
        if(distance <=2)
        {
            animator.SetBool("isAttacking", true);
            AudioSource.PlayClipAtPoint(attack, agent.transform.position, attackVolume);
        }
        if(distance >2)
        {
            animator.SetBool("isAttacking", false);
        }
    }
    
}
