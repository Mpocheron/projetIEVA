using UnityEngine;

public class ContactDetection : MonoBehaviour
{
    private NPCControler npcController;

    public bool isTouchingPlayer { get; protected set; }

    void Start()
    {
        isTouchingPlayer = false;
        npcController = GetComponentInParent<NPCControler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }

        if (other.CompareTag("Projectile"))
        {
            npcController.projectileHit();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}
