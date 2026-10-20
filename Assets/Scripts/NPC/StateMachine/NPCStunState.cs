using UnityEngine;

public class NPCStunState : State
{
    public float stunTime;

    public override void Enter()
    {
        navMeshAgent.isStopped = true;

        NPCmaterial.color = Color.white;
    }

    public override void Exit()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.ResetPath();
    }

    public override void Do()
    {
        if (time > stunTime)
        {
            IsComplete = true;
        }
    }
}
