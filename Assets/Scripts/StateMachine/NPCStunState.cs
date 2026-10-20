using UnityEngine;

public class NPCStunState : State
{
    public float stunTime;

    public override void Enter()
    {
        NPCmaterial.color = Color.white;
        navMeshAgent.ResetPath();
    }

    public override void Exit()
    {

    }

    public override void Do()
    {
        if (time > stunTime)
        {
            IsComplete = true;
        }
    }
}
