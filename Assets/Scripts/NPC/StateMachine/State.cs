using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    public bool IsComplete { get; protected set; }

    protected float startTime;

    public float time => Time.time - startTime;

    protected NavMeshAgent navMeshAgent;

    protected Detection detection;

    protected Material NPCmaterial;

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void Setup(NavMeshAgent _navMeshAgent, Detection _detection, Material _npcMaterial) { 
        navMeshAgent = _navMeshAgent;
        detection= _detection;
        NPCmaterial = _npcMaterial;
    }

    public void Initialise()
    {
        IsComplete = false;
        startTime = Time.time;
    }
}
