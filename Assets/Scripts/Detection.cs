using System;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public bool isPlayerDetected { get; protected set; }

    public Collider playerCollider { get; protected set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlayerDetected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = true;
            playerCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = false;
            playerCollider = null;
        }
    }
}
