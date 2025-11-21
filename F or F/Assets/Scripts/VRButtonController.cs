using UnityEngine;
using UnityEngine.SceneManagement;

public class VRButtonController : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneName; // Name of the scene to load

    [Header("Audio Settings")]
    public AudioSource audioSource; // Assign your AudioSource here

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

    /// <summary>
    /// Call this on the Audio button's OnClick()
    /// </summary>
    public void ToggleAudio()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
            else
                audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned on VRButtonController.");
        }
    }
}
