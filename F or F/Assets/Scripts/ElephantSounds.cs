using UnityEngine;
using UnityEngine.InputSystem;

public class ElephantSounds : MonoBehaviour
{
    [Header("Trigger Sound Source")]
    public AudioSource triggerAudioSource;  // The AudioSource that will play the sound

    [Header("XR Trigger Input")]
    public InputActionProperty triggerAction; // Reference to XR trigger press

    private bool triggerPressed = false;

    void Update()
    {
        HandleTriggerSound();
    }

    private void HandleTriggerSound()
    {
        if (triggerAudioSource == null) return;

        float triggerValue = triggerAction.action.ReadValue<float>();

        // Detect trigger press down
        if (triggerValue > 0.5f && !triggerPressed)
        {
            triggerAudioSource.Play();
            triggerPressed = true;
        }

        // Reset when released
        if (triggerValue < 0.2f)
        {
            triggerPressed = false;
        }
    }
}
