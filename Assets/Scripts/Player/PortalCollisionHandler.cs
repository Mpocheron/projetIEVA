using UnityEngine;

public class PortalCollisionHandler : MonoBehaviour
{
    private GameHandler gameMasterScript;

    [Space]

    public AudioSource playerAudio;
    public AudioClip disparitionClip;
    private void Start()
    {
        gameMasterScript = GameObject.Find("GameMaster").GetComponent<GameHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            playerAudio.clip = disparitionClip;
            playerAudio.volume = 1f;
            playerAudio.Play();

            gameMasterScript.GameEnding();
        }
    }
}
