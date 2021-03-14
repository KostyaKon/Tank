using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 10.0f;
    private const float Y_ANGLE_MAX = 30.0f;

    private const float X_ANGLE_MIN = -10.0f;
    private const float X_ANGLE_MAX = 10.0f;

    public Transform lookAt;
    public Transform camTransform;

    private float currentX = 0.0f;
    private float currentY = 20.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        camTransform.localRotation = Quaternion.Euler(currentY, currentX, 0);
    }
}
