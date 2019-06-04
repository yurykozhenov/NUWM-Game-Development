using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    float pitch;

    void LateUpdate()
    {
        pitch += rotationSpeed * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        var transform1 = transform;
        var eulerAngles = transform1.eulerAngles;

        eulerAngles = new Vector3(-pitch, eulerAngles.y, eulerAngles.z);
        transform1.eulerAngles = eulerAngles;
    }
}
