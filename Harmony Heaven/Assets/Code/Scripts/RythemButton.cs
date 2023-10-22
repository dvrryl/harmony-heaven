using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythemButton : MonoBehaviour
{
    public Button button;
    public Sprite image1Sprite; // Sprite gambar pertama
    public Sprite image2Sprite; // Sprite gambar kedua
    public KeyCode Keyboard;

    private Image imageComponent; // Komponen Image pada Button
    private bool buttonPressed; // Menyimpan status tombol ditekan

    void Start()
    {
        // Mendapatkan komponen Image dari Button
        imageComponent = button.GetComponent<Image>();

        // Set gambar pertama sebagai gambar awal
        imageComponent.sprite = image1Sprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(Keyboard))
        {
            // Set gambar kedua sebagai gambar saat tombol ditekan
            imageComponent.sprite = image2Sprite;

            // Set status tombol ditekan menjadi true
            buttonPressed = true;

            // Debug.Log("Semua kombinasi rythm telah ditekan!");
        }
        if (Input.GetKeyUp(Keyboard))
        {
            // Jika tombol dilepas dan tombol telah ditekan sebelumnya, biarkan gambar menjadi gambar kedua
            if (buttonPressed)
            {
                imageComponent.sprite = image2Sprite;
            }
            else
            {
                // Jika tombol tidak pernah ditekan, kembalikan ke gambar pertama
                imageComponent.sprite = image1Sprite;
            }

            // Reset status tombol ditekan
            buttonPressed = false;
        }
    }
}
