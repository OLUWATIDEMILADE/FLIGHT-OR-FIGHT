using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // <-- needed for scene loading

public class Navigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject homePanel;
    public GameObject infoPanel;
    public GameObject settingsPanel;

    [Header("Scene Settings")]
    public string nextSceneName = "NextScene"; // name of the next scene to load

    // Start with Home panel active
    private void Start()
    {
        ShowHome();
    }

    // Show Home Panel
    public void ShowHome()
    {
        homePanel.SetActive(true);
        infoPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    // Show Info Panel
    public void ShowInfo()
    {
        homePanel.SetActive(false);
        infoPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    // Show Settings Panel
    public void ShowSettings()
    {
        homePanel.SetActive(false);
        infoPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // Load Next Scene
    public void GoToNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set in Navigation script.");
        }
    }
}
