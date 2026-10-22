using UnityEngine;
using UnityEngine.AI;

public class NPCControler : MonoBehaviour
{
    /* --- State Variables ---*/

    public NPCPatrolState patrolState;
    public NPCChaseState chaseState;
    public NPCStunState stunState;
    public NPCIdleState idleState;

    State state;


    /* --- Blackboard Variables ---*/

    public NavMeshAgent navMeshAgent;

    public Detection detection;

    public ContactDetection contactDetection;


    void Start()
    {
        Material material = GetComponent<Renderer>().material;

        patrolState.Setup(navMeshAgent, detection, contactDetection, material);
        chaseState.Setup(navMeshAgent, detection, contactDetection, material);
        stunState.Setup(navMeshAgent, detection, contactDetection, material);
        idleState.Setup(navMeshAgent, detection, contactDetection, material);
        
        state = patrolState;
    }

    void Update()
    {
        if (state.IsComplete)
        {
            state.Exit();
            SelectState();
        }

        state.Do();
    }

    protected void SelectState()
    {
        if (contactDetection.isTouchingPlayer) {
            state = idleState;
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

    public void projectileHit()
    {
        state.Exit();

        state = stunState;

        state.Initialise();
        state.Enter();
    }

}
