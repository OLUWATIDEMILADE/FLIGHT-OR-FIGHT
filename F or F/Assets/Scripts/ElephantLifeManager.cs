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

    private bool isDead = false; // Prevent double triggers

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
        if (isDead) return; // Prevent extra damage after death

        currentLives -= amount;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            currentLives = 0;
            isDead = true;
            UpdateLivesUI();
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        // DAMAGE TRANSFER — Works with Rigidbody + CapsuleCollider
        if (collision.gameObject.CompareTag("Arrow"))
        {
            ReduceLife(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        // When elephant reaches Exit → load scene
        if (other.CompareTag("Exit"))
        {
            isDead = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
