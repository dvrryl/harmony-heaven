using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    // Array untuk menyimpan referensi ke komponen Image pada GameObject yang ingin diubah warnanya
    public Image[] imageComponents;

    // Array untuk menyimpan nilai hexadecimal yang sesuai dengan jumlah GameObject
    public string[] hexColors;

    void Start()
    {
        // Pastikan jumlah GameObject dan jumlah nilai hexadecimal sama
        if (imageComponents.Length != hexColors.Length)
        {
            Debug.LogError("Jumlah GameObject dan jumlah nilai hexadecimal tidak sama!");
            return;
        }

        // Panggil fungsi untuk mengubah warna pada setiap GameObject Image
        ChangeImageColors();
    }

    void ChangeImageColors()
    {
        // Set warna untuk setiap GameObject Image sesuai dengan nilai hexadecimal yang bersesuaian
        for (int i = 0; i < imageComponents.Length; i++)
        {
            try
            {
                Color color = HexToColor(hexColors[i]);
                imageComponents[i].color = color;
            }
            catch (Exception e)
            {
                Debug.LogError("Gagal mengubah warna untuk index " + i + ": " + e.Message);
            }
        }
    }

    Color HexToColor(string hex)
    {
        // Parse nilai hexadecimal dan kembalikan sebagai Color
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            // Tampilkan nilai hexadecimal yang bermasalah
            Debug.LogError("Gagal mengonversi nilai hexadecimal ke warna! Hex: " + hex);
            throw new Exception("Gagal mengonversi nilai hexadecimal ke warna!");
        }
    }
}