using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ElephantLifeManager : MonoBehaviour
{
    [Header("Elephant Settings")]
    public int startLives = 100;
    private int currentLives;

    [Header("UI (TextMeshPro)")]
    public TextMeshProUGUI livesText;

    [Header("Scene Settings")]
    public string sceneToLoad = "INFO"; // Scene to load when elephant dies or reaches Exit

    void Start()
    {
        currentLives = startLives;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Elephant Lives: " + currentLives;
    }

    public void ReduceLife(int amount)
    {
        currentLives -= amount;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            currentLives = 0;
            UpdateLivesUI();
            // Elephant dies
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            ReduceLife(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When elephant reaches Exit object
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
