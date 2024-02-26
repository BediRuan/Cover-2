using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // This single method is enough to load any scene passed to it.
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}