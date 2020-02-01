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

    // Update is called once per frame
    void Update()
    {
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

        if (distance <= 10f)
        {
            if (playerToFollow.activeSelf)
            {
                if (attackSpeed >= 3)
                {
                    playerScript.takeDamage();
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
}