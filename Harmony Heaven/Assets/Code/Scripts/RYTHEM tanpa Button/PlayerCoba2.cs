using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoba2 : MonoBehaviour
{
    public ScoreManagerP1 scoreManagerP1;
    public int c = 0;
    public int p = 0;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    public PlayerCoba3 P2;
    public playerController animasiP1;
    public GameObject gameOverText;

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
    public void ProcessPValue(int pValue)
    {
        p = pValue;
        if (p == 3)
        {
            animasiP1.ProcessRValue(2);
            TakeDamage(100);
            p = 0;
        }
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    private void Update()
    {
        if (c == 1)
        {
            P2.ProcessoOValue(2);
            TakeDamage(20);
            ProcessPValue(p);
            c = 0;
            animator.SetTrigger("TakeDamage");
        }
        if (currentHealth <= 0)
        {
            Managerscore();
            // Trigger game over
            GameManager.Instance.GameOver();
            currentHealth = 1;
        }
    }
    void Managerscore()
    {
        ScoreManagerP1 scoreManager = FindObjectOfType<ScoreManagerP1>();

        if (scoreManager != null)
        {
            scoreManager.ReadAndUpdateScoreFromTextMeshProUGUI();
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