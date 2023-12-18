using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCoba1 : MonoBehaviour
{
    public int b = 0;
    public int p = 0;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    public PlayerCoba4 P1;
    //private AudioSource audioSource;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //audioSource = GetComponent<AudioSource>();
    }

    public void ProcessBValue(int bValue)
    {
        b = bValue;
        

        // Trigger animation when b is set to 1
        /*        if (b == 1)
                {
                    TakeDamage(20);
                    //audioSource.Play();
                    b = 0;
                    animator.SetTrigger("TakeDamageTrigger");
                }*/
    }
    public void ProcessPValue(int pValue)
    {
        p = pValue;
        if (p == 3)
        {
            TakeDamage(100);
            p = 0;
        }
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }

    private void Update()
    {
        if (b == 1)
        {
            P1.ProcessoOValue(2);
            TakeDamage(20);
            ProcessPValue(p);
            b = 0;
            animator.SetTrigger("BasicAttack");
            ResetTrigger();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void ResetTrigger()
    {
        animator.ResetTrigger("BasicAttack");
    }
}