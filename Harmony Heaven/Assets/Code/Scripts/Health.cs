using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    private float maxHealth = 1000f;
    private float currentHealth = 1000f;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        fillImage.color = fullHealthColor;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        float normalizedHealth = currentHealth / maxHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, normalizedHealth);
    }
}
