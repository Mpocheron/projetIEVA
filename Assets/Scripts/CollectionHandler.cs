using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionHandler : MonoBehaviour
{
    [HideInInspector] public float playerPoids = 0;
    [HideInInspector] public int playerValeur = 0;

    private GameObject player;

    public TextMeshProUGUI valeurText;
    public TextMeshProUGUI poidsText;
    public TextMeshProUGUI lastCollectibleText;

    public Stack<GameObject> inventaire = new();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            playerPoids += other.gameObject.GetComponent<CollectibleVariables>().poids;
            playerValeur += other.gameObject.GetComponent<CollectibleVariables>().valeur;

            inventaire.Push(other.gameObject);

            valeurText.text = "Valeur : " + playerValeur.ToString();
            poidsText.text = "Poids : " + playerPoids.ToString();
            lastCollectibleText.text = "Last Collectible : " + inventaire.Peek().name;

            Destroy(other.gameObject);
        }
    }
}
