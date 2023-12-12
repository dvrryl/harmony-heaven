using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    // Adjust this variable to set the rotation speed
    public float rotationSpeed = 5.0f;

    void Update()
    {
        // Get the current rotation
        float currentRotation = transform.rotation.eulerAngles.z;

        // Calculate the new rotation based on the speed and time
        float newRotation = currentRotation + rotationSpeed * Time.deltaTime;

        // Apply the new rotation
        transform.rotation = Quaternion.Euler(0, 0, newRotation);
    }
}
