using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProComponent; // Objek TextMeshProUGUI yang ingin diubah teksnya

    void Start()
    {
        // Pastikan objek textMeshProComponent telah ditetapkan sebelum menggunakannya
        if (textMeshProComponent == null)
        {
            Debug.LogError("Error: TextMeshProUGUI component is not set! Please assign a TextMeshProUGUI component.");
        }

        // Contoh penggunaan saat Start
        SetTextDynamically("123");
    }

    // Metode untuk mengubah teks TextMeshProUGUI secara dinamis
    private void SetTextDynamically(string newText)
    {
        if (textMeshProComponent != null)
        {
            // Set teks secara dinamis tanpa melibatkan inspector
            textMeshProComponent.text = newText;
        }
        else
        {
            Debug.LogError("Error: TextMeshProUGUI component is not set! Please assign a TextMeshProUGUI component.");
        }
    }
}
