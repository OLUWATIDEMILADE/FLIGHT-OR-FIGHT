using UnityEngine;

public class CameraHeightLock : MonoBehaviour
{
    public float fixedHeight = 1.7f; // Set camera height in meters

    void LateUpdate()
    {
        Vector3 pos = transform.localPosition;
        pos.y = fixedHeight;
        transform.localPosition = pos;
    }
}
