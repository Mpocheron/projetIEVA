using UnityEngine;
using UnityEngine.AI;

public class NPCPatrolState : State
{
    [SerializeField]
    public Transform[] checkPoints;

    private int destPoint = 0;

    public float patrolSpeed = 3.5f;

    public override void Enter()
    {
        navMeshAgent.speed = patrolSpeed;
        navMeshAgent.destination = checkPoints[destPoint].position;

        NPCmaterial.color = Color.blue;
    }

    public override void Exit()
    {

    }

    public override void Do()
    {
        if (detection.isPlayerDetected)
        {
            IsComplete = true;
            return;
        }

        if (navMeshAgent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if (checkPoints.Length == 0) return;

        navMeshAgent.destination = checkPoints[destPoint].position;

        destPoint = (destPoint + 1) % checkPoints.Length;
    }
}
