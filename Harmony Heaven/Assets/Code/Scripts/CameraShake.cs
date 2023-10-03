using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f; // The duration of the camera shake in seconds.
    public float shakeIntensity = 0.1f; // The intensity of the camera shake.

    private float shakeTimer = 0.0f; // The current time of the camera shake.

    void Update()
    {
        if (shakeTimer > 0.0f)
        {
            // Shake the camera.
            transform.position += new Vector3(Random.Range(-shakeIntensity, shakeIntensity), Random.Range(-shakeIntensity, shakeIntensity), 0.0f);

            // Reduce the shake timer.
            shakeTimer -= Time.deltaTime;
        }
    }

    public void Shake()
    {
        // Start the camera shake.
        shakeTimer = shakeDuration;
    }
}