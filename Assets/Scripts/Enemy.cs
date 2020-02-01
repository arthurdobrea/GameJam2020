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
    private Animator animator;

    private Vector3 selfPosition;
    private Vector3 playerPosition;
    private float agroRadius;
    private Player playerScript;
    private float health = 20;

    public GameObject currentLocationToScout;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerToFollow.GetComponent<Player>();
        agent.GetComponent<NavMeshAgent>();
        // animator.GetComponent<Animator>();
        // animator.SetFloat("InputY", -1); // Idle
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
            agent.SetDestination(currentLocationToScout.transform.position);
        }
        else
        {
            agent.SetDestination(currentLocationToScout.transform.position);
        }
    }

    private void Move(Vector3 p)
    {
        agent.SetDestination(p);
        animator.SetFloat("InputY", 0); // Run
    }

    // Update is called once per frame
    void Update()
    {
        DoDamage(10);
        selfPosition = transform.position;
        playerPosition = playerToFollow.transform.position;
        float distance = Vector3.Distance(selfPosition, playerPosition);

        if (distance <= 20f)
        {
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
        DoDamage(10);
        if (distance <= 10f)
        {
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
    }

    public void takeDamage()
    {
        health -= 10;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void DoDamage(int damage)
    {
        // Debug.Log("Here");
        // animator.SetFloat("InputY", 1); // Attack
        playerToFollow.GetComponent<Player>().health -= damage;
        if (playerToFollow.GetComponent<Player>().health <= 0)
        {
            Application.Quit();
        }
    }
}