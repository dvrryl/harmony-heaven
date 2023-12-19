using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public int q;
    public Image[] imageComponents;

    // Define two arrays for hex colors
    public string[] hexColorsArray1;
    public string[] hexColorsArray2;

    void Start()
    {
        change();

        
    }
    private void change()
    {
        string[] selectedHexColors;
        // Pilih array hexColors berdasarkan nilai q
        if (q == 2)
        {
            selectedHexColors = hexColorsArray1;
        }
        else if (q == 3)
        {
            selectedHexColors = hexColorsArray2;
        }
        else
        {
            Debug.LogError("Nilai q tidak sesuai dengan kondisi yang diharapkan!");
            return;
        }

        // Periksa apakah panjang array hexColors yang dipilih sesuai dengan panjang imageComponents
        if (imageComponents.Length != selectedHexColors.Length)
        {
            Debug.LogError("Jumlah GameObject dan jumlah nilai hexadecimal tidak sama!");
            return;
        }

        // Panggil fungsi untuk mengubah warna berdasarkan array hexColors yang dipilih
        ChangeImageColors(selectedHexColors);
    }
    void ChangeImageColors(string[] hexColors)
    {
        // Set warna untuk setiap GameObject Image berdasarkan nilai hex color yang sesuai
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
    private void Update()
    {
        change();
    }
}