using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCoba3 : MonoBehaviour
{
    public int maxMana = 500;
    public int currentMana;
    public ManaBar manabar;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("B");
        manabar.SetMaxHealth(maxMana);
        Debug.Log("C");
        manabar.SetHealth(currentMana);
        Debug.Log("D");
        Debug.Log("A");
        currentMana = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        //manabar.SetMaxHealth(currentHealth);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Panggil fungsi TakeDamage dan tambahkan 20 ke currentHealth
            TakeDamage(170);
        }
    }

    void TakeDamage(int damageAmount)
    {
        currentMana = currentMana + damageAmount;

        // Pastikan currentHealth tidak melebihi maxHealth
        currentMana = Mathf.Min(currentMana, maxMana);

        // Update tampilan health bar
        manabar.SetHealth(currentMana);
    }
}
