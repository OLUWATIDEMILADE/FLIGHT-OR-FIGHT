using UnityEngine;
using UnityEngine.SceneManagement;

public class VRButtonController : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneName; // Name of the scene to load

    /// <summary>
    /// Call this on the Scene button's OnClick()
    /// </summary>
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name not set on VRButtonController.");
        }
    }
}
