using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    void Start()
    {
        // Get the Animator component from the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (Input.GetButtonDown("Fire1"))  
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
        Destroy(bullet, 2f);
    }
}*/

public class PlayerScript : MonoBehaviour
{
    public GameObject projectilePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowProjectile();
        }
    }

    void ThrowProjectile()
    {
        // Instantiate the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        // You may need to adjust the projectile's starting position based on your sprite and game design

        // Destroy the projectile after a certain time to prevent clutter
        Destroy(projectile, 2f);
    }
}