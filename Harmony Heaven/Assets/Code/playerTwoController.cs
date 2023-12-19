/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoController : MonoBehaviour
{
    private Animator animator;
    public GameObject projectilePrefab;
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

        if (Input.GetKeyDown(KeyCode.Slash))
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
        Destroy(projectile, 3f);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoController : MonoBehaviour
{
    private Animator animator;
    public float bulletSpeed = 10f;
    public int r;

    void Start()
    {
        // Get the Animator component from the GameObject
        animator = GetComponent<Animator>();
    }
    public void ProcessRValue(int rValue)
    {
        r = rValue;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        if (r == 2)
        {
            // Trigger the slash animation
            animator.SetTrigger("SlashTrigger");
            r = 0;
        }
        /*if (Input.GetKeyDown(KeyCode.Slash))
        {
            // Trigger the slash animation
            animator.SetTrigger("SlashTrigger");
        }*/
    }

    // Remove the ThrowProjectile method

    // You can add additional logic here or in a separate method if needed
}

