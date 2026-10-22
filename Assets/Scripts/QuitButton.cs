using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        if (Application.isEditor)
        {
# if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }
        else
        {
            Application.Quit();
        }
    }
}
