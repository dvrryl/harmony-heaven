using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedkeyboardDisplay : MonoBehaviour
{
    public Image[] imageComponents;
    public Sprite[] imageSprites;

    private void Start()
    {
        SetSpritesManually(); // Ganti pemanggilan ke metode yang memetakan sprite secara manual.
    }

    private void SetSpritesManually()
    {
        // Pastikan jumlah elemen pada imageComponents sesuai dengan jumlah elemen pada imageSprites.
        if (imageComponents.Length == imageSprites.Length)
        {
            for (int i = 0; i < imageComponents.Length; i++)
            {
                imageComponents[i].sprite = imageSprites[i];
            }
        }
        else
        {
            Debug.LogError("Jumlah imageComponents tidak sesuai dengan jumlah imageSprites. Sesuaikan elemen-elemen ini dengan benar.");
        }
    }
}