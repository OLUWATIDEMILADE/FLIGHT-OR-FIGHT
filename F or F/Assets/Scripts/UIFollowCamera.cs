using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    public Transform cameraTransform; // assign XR Camera
    public Vector3 offset = new Vector3(0, 0, 2); // distance in front of camera

    void LateUpdate()
    {
        if (cameraTransform != null)
        {
            // Follow camera position + offset
            transform.position = cameraTransform.position + cameraTransform.forward * offset.z
                               + cameraTransform.up * offset.y
                               + cameraTransform.right * offset.x;

            // Make UI face the camera
            transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
        }
    }
}
