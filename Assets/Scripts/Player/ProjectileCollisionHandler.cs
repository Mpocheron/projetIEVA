using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    private GameHandler gameMasterScript;

    public GameObject prefab;

    private int valeur;

    private void Start()
    {
        gameMasterScript = GameObject.Find("GameMaster").GetComponent<GameHandler>();
        valeur = prefab.GetComponent<CollectibleVariables>().valeur;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Portal")) gameMasterScript.score += valeur;
        Destroy(gameObject);
    }
}
