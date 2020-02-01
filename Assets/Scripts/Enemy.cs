using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject playerToFollow;
    public NavMeshAgent agent;
    public GameObject[] positionsToScout;
    public float attackSpeed;
    public Animator animator;

    private Vector3 selfPosition;
    private Vector3 playerPosition;
    private float agroRadius;
    private Player playerScript;
    public float health;
    private bool dead = false;
    public GameObject currentLocationToScout;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerToFollow.GetComponent<Player>();
        agent.GetComponent<NavMeshAgent>();
        animator.GetComponent<Animator>();
        animator.Play("Idle");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, agroRadius / 2);
    }

    private void Scout()
    {
        int range = Random.Range(1, 5);

        if (Vector3.Distance(transform.position, currentLocationToScout.transform.position) < 5)
        {
            // Debug.Log(Vector3.Distance(transform.position, currentLocationToScout.transform.position));
            currentLocationToScout = positionsToScout[range];
            Move(currentLocationToScout.transform.position);
        }
        else
        {
            Move(currentLocationToScout.transform.position);
        }
    }

    private void Move(Vector3 p)
    {
        agent.SetDestination(p);
        animator.Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        selfPosition = transform.position;
        playerPosition = playerToFollow.transform.position;
        float distance = Vector3.Distance(selfPosition, playerPosition);

        if (!dead)
        {
            if (distance <= 2f)
            {
                agent.Stop();
                if (playerToFollow.activeSelf)
                {
                    if (attackSpeed >= 3)
                    {
                        DoDamage(10);
                        attackSpeed = 0;
                    }
                    else
                    {
                        attackSpeed += 1 * Time.deltaTime;
                    }
                }
            }
            else if (distance <= 10f)
            {
                agent.Resume();
                Quaternion lookAtPlayer = Quaternion.LookRotation(playerPosition - selfPosition);

                lookAtPlayer.x = 0;
                lookAtPlayer.z = 0;

                transform.rotation = Quaternion.Slerp(transform.rotation, lookAtPlayer, 7F * Time.deltaTime);
                agent.SetDestination(playerPosition);
            }
            else
            {
                Scout();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            animator.Play("Death");
            dead = true;
            agent.Stop();
        }
    }

    public void DoDamage(float damage)
    {
        playerToFollow.GetComponent<Player>().TakeDamage(damage);
        animator.Play("Attack");
    }
}