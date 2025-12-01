using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVolumeManager : MonoBehaviour
{
    public static GlobalVolumeManager Instance;

    [Range(0f, 1f)] public float masterVolume = 1f;
    public bool isMuted = false;

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSettings();
        ApplyToAllAudioSources();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyToAllAudioSources();
    }

    public void SetVolume(float value)
    {
        masterVolume = Mathf.Clamp01(value);
        SaveSettings();
        ApplyToAllAudioSources();
    }

    // 🔥 NEW — Mute Toggle
    public void ToggleMute()
    {
        isMuted = !isMuted;      // Switch between true/false
        SaveSettings();
        ApplyToAllAudioSources();
    }

    public void ApplyToAllAudioSources()
    {
        float finalVolume = isMuted ? 0f : masterVolume;

        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            audio.volume = finalVolume;
        }
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    private void LoadSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
    }
}
