using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NPCNavigation : MonoBehaviour
{
    [SerializeField]
    public Transform[] points;

    private int destPoint = 0;

    private NavMeshAgent navMeshAgent;
    
    
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        navMeshAgent.autoBraking = false;

        GoToNextPoint();
    }
    
    void GoToNextPoint()
    {
        if (points.Length == 0) return;

        navMeshAgent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }
}
