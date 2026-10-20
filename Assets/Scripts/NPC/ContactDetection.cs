using UnityEngine;

public class ContactDetection : MonoBehaviour
{
    public bool isTouchingPlayer { get; protected set; }

    void Start()
    {
        isTouchingPlayer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
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
