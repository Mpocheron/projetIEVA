using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    [HideInInspector] public int gameState = 0;

    public GameObject collectibles;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nbColText;

    public TextMeshPro scoreTextPortal;

    [Space]

    public GameObject player;
    public CollectionHandler collectionHandler;

    [Space]

    public Canvas canvasGame;
    public Canvas canvasEnding;

    [Space]
    public GameObject portal;

    private int nbCollectible;
    private float chrono = 0;

    [Space]

    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public GameObject capsulePrefab;

    private void Start()
    {
        nbCollectible = collectibles.transform.childCount;
        canvasEnding.enabled = false;
    }

    private void Update()
    {
        if (gameState == 0) chrono += Time.deltaTime;

        scoreText.text = "Score : " + score.ToString();
        scoreTextPortal.text = scoreText.text;
        DisplayTime(chrono);
        nbColText.text = "Objets collectés : " + (nbCollectible - collectibles.transform.childCount).ToString() + "/" + nbCollectible.ToString();
    }
    void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float centiseconds = Mathf.FloorToInt((time * 100) % 100);

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, centiseconds);
    }

    public void GameEnding()
    {
        gameState = 1;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.transform.position = portal.transform.position + new Vector3(0, -11.5f, 0);

        player.GetComponentInChildren<Camera>().transform.rotation = Quaternion.Euler(0, 0, 0);
        player.GetComponentInChildren<Camera>().fieldOfView = 60;

        GetColletion();

        canvasGame.enabled = false;
        canvasEnding.enabled = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void GetColletion()
    {
        while (collectionHandler.inventaire.Count > 0)
        {
            string objName = collectionHandler.inventaire.Pop();

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

            score += obj.GetComponent<CollectibleVariables>().valeur;
        }
    }
}

