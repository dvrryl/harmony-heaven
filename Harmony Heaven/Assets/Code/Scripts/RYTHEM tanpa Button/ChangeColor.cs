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
        // Choose the appropriate hex color array based on the value of q
        string[] selectedHexColors = (q == 2) ? hexColorsArray1 : (q == 3) ? hexColorsArray2 : null;

        // Check if the selected hex color array is valid
        if (selectedHexColors == null)
        {
            Debug.LogError("Nilai q tidak sesuai dengan kondisi yang diharapkan!");
            return;
        }

        // Check if the length of the selected hex color array matches the length of imageComponents
        if (imageComponents.Length != selectedHexColors.Length)
        {
            Debug.LogError("Jumlah GameObject dan jumlah nilai hexadecimal tidak sama!");
            return;
        }

        // Call the function to change colors based on the selected hex color array
        ChangeImageColors(selectedHexColors);
    }

    void ChangeImageColors(string[] hexColors)
    {
        // Set color for each Image GameObject based on the corresponding hex color value
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
        // Parse hexadecimal value and return as Color
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            // Display problematic hexadecimal value
            Debug.LogError("Gagal mengonversi nilai hexadecimal ke warna! Hex: " + hex);
            throw new Exception("Gagal mengonversi nilai hexadecimal ke warna!");
        }
    }
}