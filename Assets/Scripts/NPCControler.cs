using UnityEngine;
using UnityEngine.AI;

public class NPCControler : MonoBehaviour
{
    public NPCPatrolState patrolState;
    public NPCChaseState chaseState;
    public NPCStunState stunState;

    State state;


    public NavMeshAgent navMeshAgent;

    public Detection detection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Material material = GetComponent<Renderer>().material;

        patrolState.Setup(navMeshAgent, detection, material);
        chaseState.Setup(navMeshAgent, detection, material);
        stunState.Setup(navMeshAgent, detection, material);
        
        state = patrolState;
    }

    // Update is called once per frame
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
