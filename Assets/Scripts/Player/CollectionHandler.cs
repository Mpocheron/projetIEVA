using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionHandler : MonoBehaviour
{
    private GameHandler gameMasterScript;

    [HideInInspector] public int playerPoids = 0;
    [HideInInspector] public int playerValeur = 0;

    private GameObject player;

    public TextMeshProUGUI valeurText;
    public TextMeshProUGUI poidsText;
    public TextMeshProUGUI lastCollectibleText;

    [Space]

    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public GameObject capsulePrefab;

    public Stack<string> inventaire = new();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            playerPoids += other.gameObject.GetComponent<CollectibleVariables>().poids;
            playerValeur += other.gameObject.GetComponent<CollectibleVariables>().valeur;

            inventaire.Push(other.gameObject.GetComponent<CollectibleVariables>().nom);

            valeurText.text = "Valeur : " + playerValeur.ToString();
            poidsText.text = "Poids : " + playerPoids.ToString();
            lastCollectibleText.text = "Last Collectible : " + inventaire.Peek();

            Destroy(other.gameObject);
        }
    }

    public void ObjectPopped(string objName)
    {

        GameObject obj = null;

        switch (objName)
        {
            case "Sphere":
                obj = spherePrefab;
                break;

            case "Cube":
                obj = cubePrefab;
                break;

            case "Cylinder":
                obj = cylinderPrefab;
                break;

            case "Capsule":
                obj = capsulePrefab;
                break;

            default:
                Debug.LogError("Erreur objet jeté");
                break;
        }

        playerPoids -= obj.GetComponent<CollectibleVariables>().poids;
        playerValeur -= obj.GetComponent<CollectibleVariables>().valeur;

        valeurText.text = "Valeur : " + playerValeur.ToString();
        poidsText.text = "Poids : " + playerPoids.ToString();

        lastCollectibleText.text = (inventaire.Count == 0) ? "" : "Last Collectible : " + inventaire.Peek();
    }

    public void PlayerHit()
    {
        ObjectPopped(inventaire.Pop());
    }
}
