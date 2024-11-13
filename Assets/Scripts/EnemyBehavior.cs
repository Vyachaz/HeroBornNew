using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;

    private int locationIndex = 0;
    

    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        locationIndex = (int) Random.Range(0f, 4f);

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.6f && !agent.pathPending) 
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) 
        {
            return; 
        }
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            agent.destination = player.position;
            Debug.Log("Player detected - - attack!!!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player out of ranfe, resume patrol.");
        }
    }

}
