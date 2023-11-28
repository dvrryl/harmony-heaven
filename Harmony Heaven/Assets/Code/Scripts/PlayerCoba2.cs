using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoba2 : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;

    // Event untuk memberi tahu GameController bahwa urutan benar dicapai oleh PlayerCoba2
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequencePlayer2;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);

            // Memberi tahu GameController bahwa urutan benar dicapai oleh PlayerCoba2
            if (OnCorrectSequencePlayer2 != null)
            {
                OnCorrectSequencePlayer2();
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}