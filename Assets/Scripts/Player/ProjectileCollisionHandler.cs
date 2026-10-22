using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    private GameHandler gameMasterScript;

    public GameObject prefab;

    [Space]

    public AudioSource audioProjectile;
    public AudioClip disparitionClip;
    public AudioClip destructionClip;


    private Transform projectilsAnchor;

    private int valeur;

    private void Start()
    {
        gameMasterScript = GameObject.Find("GameMaster").GetComponent<GameHandler>();
        valeur = prefab.GetComponent<CollectibleVariables>().valeur;
        projectilsAnchor = GameObject.Find("Projectiles").GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision other)
    {
        AudioSource soundObj = Instantiate(audioProjectile, projectilsAnchor);
        soundObj.transform.position = transform.position;

        if (other.gameObject.CompareTag("Portal"))
        {
            gameMasterScript.score += valeur;
            soundObj.clip = disparitionClip;
        }
        else soundObj.clip = destructionClip;

        soundObj.Play();

        Destroy(gameObject);
    }
}
