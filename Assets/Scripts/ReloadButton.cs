using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log(SceneManager.GetActiveScene());
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneName);
    }
}
