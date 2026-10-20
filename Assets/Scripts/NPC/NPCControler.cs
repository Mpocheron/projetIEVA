using UnityEngine;
using UnityEngine.AI;

public class NPCControler : MonoBehaviour
{
    /* --- State Variables ---*/

    public NPCPatrolState patrolState;
    public NPCChaseState chaseState;
    public NPCStunState stunState;

    State state;


    /* --- Blackboard Variables ---*/

    public NavMeshAgent navMeshAgent;

    public Detection detection;


    void Start()
    {
        Material material = GetComponent<Renderer>().material;

        patrolState.Setup(navMeshAgent, detection, material);
        chaseState.Setup(navMeshAgent, detection, material);
        stunState.Setup(navMeshAgent, detection, material);
        
        state = patrolState;
    }

    void Update()
    {
        if (state.IsComplete)
        {
            SelectState();
        }

        state.Do();
    }

    void SelectState()
    {
        if (state == chaseState) {
            state = stunState;
        }
        else {
            if (detection.isPlayerDetected) {
                state = chaseState;
            }
            else {
                state = patrolState;
            }
        }

        state.Initialise();
        state.Enter();
    }
}
