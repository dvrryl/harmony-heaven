using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
