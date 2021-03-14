using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera cam;

    private const float X_ANGLE_MIN = -70.0f;
    private const float X_ANGLE_MAX = 10.0f;

    private const float Z_ANGLE_MIN = -70.0f;
    private const float Z_ANGLE_MAX = 70.0f;

    private Transform gunTransform;

    private float currentX = 0.0f;
    private float currentZ = 0.0f;

    private void Start()
    {
        gunTransform = transform;
    }

    private void Update()
    {
        currentZ += Input.GetAxis("Mouse X");
        currentX -= Input.GetAxis("Mouse Y");

        currentZ = Mathf.Clamp(currentZ, Z_ANGLE_MIN, Z_ANGLE_MAX);
        currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        gunTransform.localRotation = Quaternion.Euler(currentX, 0, currentZ);
    }
}
