using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public GameObject playerToFollow;
    public NavMeshAgent agent;
    
    private Vector3 selfPosition;
    private Vector3 playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        selfPosition = transform.position;
        playerPosition = playerToFollow.transform.position;
        
        Quaternion lookAtPlayer = Quaternion.LookRotation(playerPosition - selfPosition);

        lookAtPlayer.x = 0;
        lookAtPlayer.z = 0;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtPlayer, 7F * Time.deltaTime);
            
        float distance = Vector3.Distance(selfPosition, playerPosition);

        // if (distance >= 3f)
        // {
            agent.SetDestination(playerPosition);
            // transform.Translate(Vector3.forward * 7 * Time.deltaTime);
        // }

    }
}
