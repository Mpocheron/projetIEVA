using System;
using UnityEngine;

public class NPCChaseState : State
{
    public float maxChaseTime;

    public float closeDistance = 0.1f;

    Vector3 lastSeenPosition;


    public override void Enter()
    {
        NPCmaterial.color = Color.red;

        lastSeenPosition = detection.playerCollider.transform.position;

        GetComponentInParent<NPCControler>().playerSpottedSound.Play();
    }

    public override void Exit()
    {

    }

    public override void Do()
    {
        navMeshAgent.destination = lastSeenPosition;

        if (time > maxChaseTime || contactDetection.isTouchingPlayer || (HasReachedDestination() && !detection.isPlayerDetected))
        {
            IsComplete = true;
        }
        else if (detection.isPlayerDetected)
        {
            lastSeenPosition = detection.playerCollider.transform.position;
        }
    }

    bool HasReachedDestination()
    {
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance < closeDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.magnitude == 0)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
