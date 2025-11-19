using UnityEngine;

public class GlobalVolumeManager : MonoBehaviour
{
    public static GlobalVolumeManager Instance;

    [Range(0f, 1f)]
    public float masterVolume = 1f;
    public bool isMuted = false;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSettings();
        ApplySettings();
    }

    public void SetVolume(float value)
    {
        masterVolume = value;
        ApplySettings();
        SaveSettings();
    }

    public void SetMute(bool value)
    {
        isMuted = value;
        ApplySettings();
        SaveSettings();
    }

    private void ApplySettings()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource src in sources)
        {
            if (isMuted)
            {
                src.volume = 0f;
            }
            else
            {
                src.volume = masterVolume;
            }
        }
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");

        if (PlayerPrefs.HasKey("Muted"))
            isMuted = PlayerPrefs.GetInt("Muted") == 1;
    }
}
