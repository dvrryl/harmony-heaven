using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCoba3 : MonoBehaviour
{
    public int o;
    public int maxMana = 500;
    public int currentMana;
    public ManaBar manabar;
    public PlayerCoba1 P1;
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

    public void ProcessoOValue(int oValue)
    {
        o = oValue;
        if (o == 2)
        {
            TakeDamage(170);
            o = 1;
            Ulti();
            Debug.Log("hmm");
        }
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    public void Ulti()
    {
        if (currentMana >= 500)
        {
            P1.ProcessPValue(3);
            currentMana = 0;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        ProcessoOValue(o);
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
