using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class ElephantSounds : MonoBehaviour
{
    [Header("Footsteps")]
    public AudioClip footstepClip;
    public float stepInterval = 0.5f; // interval between footsteps

    [Header("Trigger Sound")]
    public AudioClip triggerClip;
    public InputActionProperty triggerAction; // XR trigger input reference

    private AudioSource audioSource;
    private CharacterController characterController;
    private float stepTimer = 0f;

    private bool triggerPressed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleFootsteps();
        HandleTriggerPress();
    }

    private void HandleFootsteps()
    {
        if (characterController == null || footstepClip == null) return;

        Vector3 horizontalVel = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);

        if (horizontalVel.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                audioSource.PlayOneShot(footstepClip);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    private void HandleTriggerPress()
    {
        if (triggerClip == null) return;

        float triggerValue = triggerAction.action.ReadValue<float>();

        // Detect trigger DOWN event
        if (triggerValue > 0.5f && !triggerPressed)
        {
            audioSource.PlayOneShot(triggerClip);
            triggerPressed = true;
        }

        // Reset when trigger released
        if (triggerValue < 0.2f)
        {
            triggerPressed = false;
        }
    }
}
