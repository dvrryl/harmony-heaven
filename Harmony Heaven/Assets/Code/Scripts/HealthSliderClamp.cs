using UnityEngine;
using UnityEngine.UI;

public class HealthSliderClamp : MonoBehaviour
{
    public Slider healthSlider;
    public RectTransform clampTransform; // Assign the RectTransform of your sprite (background image).

    private void Update()
    {
        float clampedX = Mathf.Clamp(healthSlider.value, 0, healthSlider.maxValue);
        healthSlider.value = clampedX;

        float normalizedX = clampedX / healthSlider.maxValue;
        healthSlider.fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, normalizedX * clampTransform.rect.width);
    }
}
