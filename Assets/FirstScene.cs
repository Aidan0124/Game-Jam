using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0); // Load the first scene in Build Settings
    }
}
