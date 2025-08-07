using UnityEngine;

public class QuitApplicationBehavior : MonoBehaviour
{
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        //for in editor mode
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
