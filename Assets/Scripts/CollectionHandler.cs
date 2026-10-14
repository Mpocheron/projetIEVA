using UnityEngine;

public class CollectionHandler : MonoBehaviour
{
    public float playerPoids = 0f;
    public int playerValeur = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            playerPoids += other.gameObject.GetComponent<CollectibleVariables>().poids;
            playerValeur += other.gameObject.GetComponent<CollectibleVariables>().valeur;
        }
    }
}
