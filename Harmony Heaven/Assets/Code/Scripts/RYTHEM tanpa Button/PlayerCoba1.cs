using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCoba1 : MonoBehaviour
{
    public int b = 0;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    private AudioSource audioSource;
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
        if (b == 1)
        {
            TakeDamage(20);
            animator.SetTrigger("TakeDamageTrigger");
            //audioSource.Play();
            b = 0;
        }
    }

 /*   void Update()
    {
        if (b == 1)
        {
            TakeDamage(20);
            b = 0;
        }
    }*/

    void TakeDamage(int damage)
    {   
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
    }
}