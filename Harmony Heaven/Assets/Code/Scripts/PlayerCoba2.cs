using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoba2 : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;

    // Event untuk menerima pesan "Urutan Benar! Resetting..."
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // Berlangganan event dari ButtonPressConfirm
        ButtonPressConfirm.OnCorrectSequence += HandleCorrectSequence;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void HandleCorrectSequence()
    {
        // Menjalankan fitur TakeDamage(50) setelah menerima pesan "Urutan Benar! Resetting..."
        TakeDamage(50);
    }
}