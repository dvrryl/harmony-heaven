using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoba1 : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;

    // Event untuk memberi tahu GameController bahwa urutan benar dicapai oleh PlayerCoba1
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequencePlayer1;

    // Properti publik B yang dimiliki oleh PlayerCoba1
    public int B = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // Subscribe ke event di sini
        GameController.OnCorrectSequencePlayer1 += HandleCorrectSequencePlayer1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);

            // Memberi tahu GameController bahwa urutan benar dicapai oleh PlayerCoba1
            if (OnCorrectSequencePlayer1 != null)
            {
                OnCorrectSequencePlayer1();
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void HandleCorrectSequencePlayer1()
    {
        Debug.Log("PlayerCoba1 menerima event CorrectSequencePlayer1");

        // Implementasi logika yang lain jika perlu
    }

    // Metode untuk menerima nilai B
    public void ProcessBValue(int bValue)
    {
        Debug.Log("PlayerCoba1 menerima B = " + bValue);

        // Mengubah nilai B
        B = bValue;

        // Menjalankan sesuatu sesuai dengan nilai B
        if (B == -1)
        {
            Debug.Log("Melakukan sesuatu, contohnya: TakeDamage(100)");
            // Lakukan sesuatu sesuai dengan kebutuhan, contohnya:
            TakeDamage(100);
        }
        // Anda dapat menambahkan logika lain sesuai kebutuhan
    }
}