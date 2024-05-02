using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the car's transform
    public float smoothSpeed = 0.125f; // How quickly the camera catches up to the target

    public Vector3 offset; // Offset from the car to position the camera

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Make the camera look at the car
        transform.LookAt(target);
    }
}
