using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCoba1 : MonoBehaviour
{
    public ScoreManagerP2 scoreManagerP2;
    public int b = 0;
    public int p = 0;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    public PlayerCoba4 P1;
    public playerTwoController animasiP2;
    public GameObject gameOverText;
    public SetTriggerAnimation sta;
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
    }
    public void ProcessPValue(int pValue)
    {
        p = pValue;
        if (p == 3)
        {
            animasiP2.ProcessRValue(2);
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
            //animator.SetTrigger("BasicAttack");
            //Debug.Log("SetTrigger");
            //ResetTrigger();
            sta.SetAnim("BasicAttack");
            
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
        ScoreManagerP2 scoreManager = FindObjectOfType<ScoreManagerP2>();

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
        animator.ResetTrigger("BasicAttack");
    }
}