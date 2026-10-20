using UnityEngine;

public class NPCChaseState : State
{
    public float maxChaseTime;

    public override void Enter()
    {
        NPCmaterial.color = Color.red;
    }

    public override void Exit()
    {

    }

    public override void Do()
    {
        if (!detection.isPlayerDetected || time > maxChaseTime)
        {
            IsComplete = true;
        }
        else
        {
            navMeshAgent.destination = detection.playerCollider.transform.position;
        }
    }
}
