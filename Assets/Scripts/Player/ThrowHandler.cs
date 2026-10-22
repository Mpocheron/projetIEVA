using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowHandler : MonoBehaviour
{
    public CollectionHandler collectionHandler;

    private InputAction throwInput;

    [Space]

    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public GameObject capsulePrefab;

    [Space]

    public Transform cameraTransform; // pour l'angle verticale
    public Transform playerTransform; // pour la position

    public Transform projectilsAnchor;

    private GameObject prefab;


    private void Start()
    {
        throwInput = InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (throwInput.WasPressedThisFrame()) {
            Throw();
        }
    }

    private void Throw() {
        if (collectionHandler.inventaire.Count != 0)
        {
            string objName = collectionHandler.inventaire.Pop();

            switch (objName)
            {
                case "Sphere":
                    prefab = spherePrefab;
                    break;

                case "Cube":
                    prefab = cubePrefab;
                    break;

                case "Cylinder":
                    prefab = cylinderPrefab;
                    break;

                case "Capsule":
                    prefab = capsulePrefab;
                    break;

                default:
                    Debug.LogError("Erreur objet jeté");
                    break;
            }


            GameObject projectile = Instantiate(prefab, projectilsAnchor);

            projectile.transform.SetPositionAndRotation(playerTransform.position + new Vector3(0f, 1.5f, 0f), cameraTransform.rotation);

            Rigidbody pRigid = projectile.GetComponent<Rigidbody>();
            pRigid.linearVelocity = projectile.transform.forward * 25;

            collectionHandler.ObjectPopped(objName);
        }
    }
}
