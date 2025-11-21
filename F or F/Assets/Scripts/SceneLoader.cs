using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneLoader : MonoBehaviour
{
    private static string previousSceneName = "INFO"; // Stores the name of the last loaded scene

    // Call this method when you are about to load a new scene
    // This saves the current scene's name as the "previous scene"
    public void LoadNewScene(string sceneName)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    // Call this method to load the previously stored scene
    public void LoadPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);
        }
        else
        {
            Debug.LogWarning("No previous scene recorded. Cannot load previous scene.");
        }
    }

    // Example usage for a button or other event
    public void GoBackToPreviousSceneButton()
    {
        LoadPreviousScene();
    }
}