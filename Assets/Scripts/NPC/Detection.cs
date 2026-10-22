using System;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public bool isPlayerDetected { get; protected set; }

    public Collider playerCollider { get; protected set; }

    private int obstacleLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlayerDetected = false;
        obstacleLayer = LayerMask.NameToLayer("Obstacle");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaycastHit[] coverHits;

            Vector3 heading = other.transform.position - transform.position;

            coverHits = Physics.RaycastAll(transform.position, heading, heading.magnitude);

            if (coverHits.Length > 0)
            {
                foreach (RaycastHit hit in coverHits)
                {
                    if (hit.transform.gameObject.layer == obstacleLayer)
                    {
                        isPlayerDetected = false;
                        return;
                    }
                }

                isPlayerDetected = true;
                playerCollider = other;
            }

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player Lost");
            isPlayerDetected = false;
            playerCollider = null;
        }
    }
}
