using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

public class MenuHandler : MonoBehaviour
{
    public GameObject title;
    public GameObject buttonPlay;
    public GameObject buttonQuit;

    public AudioSource audioMenu;

    private void Start()
    {
        title.SetActive(false);
        buttonPlay.SetActive(false);
        buttonQuit.SetActive(false);

        StartCoroutine(MenuApparition());
    }

    IEnumerator MenuApparition()
    {
        yield return new WaitForSeconds(0.5f);
        audioMenu.Play();
        title.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        audioMenu.Play();
        buttonPlay.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        audioMenu.Play();
        buttonQuit.SetActive(true);
    }
}
