using UnityEngine;
using UnityEngine.AI;

public class NPCIdleState : State
{
    public float idleTime;

    public override void Enter()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.ResetPath();

        NPCmaterial.color = Color.yellow;
    }

    public override void Exit()
    {
        
    }

    public override void Do()
    {
        if (time > idleTime)
        {
            IsComplete = true;
        }
    }
}
