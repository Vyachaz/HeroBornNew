using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;

    private int locationIndex = 0;
    

    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        locationIndex = (int) Random.Range(0f, 4f);
        Debug.Log($"RANDOM ==   {locationIndex} ");

    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.6f && !agent.pathPending) 
        {
            Debug.Log($"agent.destination == {locations[locationIndex].position} ");
            MoveToNextPatrolLocation();
          //  Debug.Log("Сработал UPDATE!!!");
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
       // Debug.Log($"locationIndex ==   {locationIndex} ");
       // Debug.Log($"locations.Count == {locations.Count} ");
        if (locations.Count == 0) 
        {
           // Debug.Log($"locations.Count  {locations.Count} ");
            return; 
        }
        agent.destination = locations[locationIndex].position;
        //Debug.Log($"agent.destination == {agent.destination} ");
        locationIndex = (locationIndex + 1) % locations.Count;
       // Debug.Log($"locationIndex ==   {locationIndex} ");
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
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
