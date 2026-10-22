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
            RaycastHit coverHit;

            if (Physics.Linecast(transform.position, other.transform.position, out coverHit))
            {
                if (coverHit.transform.gameObject.layer == obstacleLayer)  // First detection is an obstacle -> player is hidden
                {
                    isPlayerDetected = false;
                    //Debug.DrawLine(transform.position, other.transform.position, Color.purple);
                }
                else
                {
                    isPlayerDetected = true;
                    //Debug.DrawLine(transform.position, other.transform.position, Color.yellow);
                }
            }
            
            playerCollider = other;
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
