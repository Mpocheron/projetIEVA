using UnityEngine;

public class PortalCollisionHandler : MonoBehaviour
{
    private GameHandler gameMasterScript;

    private void Start()
    {
        gameMasterScript = GameObject.Find("GameMaster").GetComponent<GameHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            gameMasterScript.GameEnding();
        }
    }
}
