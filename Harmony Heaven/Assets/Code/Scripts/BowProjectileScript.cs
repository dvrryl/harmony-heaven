using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowProjectileScript : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
