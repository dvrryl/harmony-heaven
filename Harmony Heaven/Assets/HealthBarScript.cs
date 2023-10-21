using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public float health = 100f;

    void Update()
    {
        // Update the health bar's size based on the current health.
        transform.localScale = new Vector3(health / 100f, 1f, 1f);

        // Clamp the health bar's position so that it doesn't go outside the border.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -Screen.width / 2 + transform.localScale.x / 2, Screen.width / 2 - transform.localScale.x / 2), transform.position.y, transform.position.z);
    }
}
