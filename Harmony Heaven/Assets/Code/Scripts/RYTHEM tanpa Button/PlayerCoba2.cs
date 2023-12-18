using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoba2 : MonoBehaviour
{
    public int c = 0;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    public PlayerCoba3 P1;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void ProcessCValue(int cValue)
    {
        c = cValue;
        // Trigger animation when c is set to 1
/*        if (c == 1)
        {
            TakeDamage(20);
            c = 0;
            //animator.SetTrigger("TakeDamage");
        }*/
    }

    void Update()
    {
        if (c == 1)
        {
            //P1.ProcessoOValue(2);
            TakeDamage(20);
            c = 0;
            animator.SetTrigger("TakeDamage");
        }
    }

    void TakeDamage(int damage)
    {   
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
    }

    public void ResetTrigger()
    {
        animator.ResetTrigger("TakeDamage");
    }
}