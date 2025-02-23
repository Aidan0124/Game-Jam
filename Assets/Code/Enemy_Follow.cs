using System;
using UnityEngine;
using UnityEngine.AI;

public class AICarController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (agent != null && player != null)
        {
            agent.destination = player.position;
        }
    }

    void OTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has been hit by the enemy!");
        }
    }
}
