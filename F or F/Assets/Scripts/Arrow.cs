using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 5f;
    public AudioClip hitSoundClip;   // Assign your sound here!
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (rb != null && rb.velocity.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(90f, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hitSoundClip != null)
            {
                // Play sound at arrow impact point
                AudioSource.PlayClipAtPoint(hitSoundClip, transform.position);
            }
        }

        Destroy(gameObject);
    }
}
