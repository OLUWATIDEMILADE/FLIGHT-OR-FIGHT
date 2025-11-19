using UnityEngine;

public class ArcherController : MonoBehaviour
{
    [Header("References")]
    public Transform shootPoint;
    public GameObject arrowPrefab;
    public Animator animator;
    public AudioSource audioSource;          // <-- Add this
    public AudioClip deathSound;             // <-- Assign in Inspector

    public float shootForce = 60f;
    public float shootInterval = 3f;

    private Transform player;
    private bool isDead = false;

    void Start()
    {
        // Automatically find the player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        InvokeRepeating(nameof(ShootAtPlayer), 2f, shootInterval);
    }

    void Update()
    {
        if (isDead || player == null) return;

        // Always face the player horizontally
        Vector3 direction = (player.position - transform.position);
        direction.y = 0;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }

    void ShootAtPlayer()
    {
        if (isDead || player == null) return;

        animator.SetTrigger("Shoot");
        Invoke(nameof(SpawnArrow), 0.4f); // Wait for animation
    }

    void SpawnArrow()
    {
        if (!arrowPrefab || !shootPoint || player == null) return;

        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 dir = (player.position + Vector3.up * 1.5f - shootPoint.position).normalized;
            rb.AddForce(dir * shootForce, ForceMode.Impulse);
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        CancelInvoke();
        animator.SetTrigger("Die");

        // Play death sound
        if (audioSource && deathSound)
            audioSource.PlayOneShot(deathSound);

        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the Player touches the Archer → die
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }
}
