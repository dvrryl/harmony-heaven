using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditTextP1 : MonoBehaviour
{
    public TextMeshProUGUI textMeshProComponent; // Objek TextMeshProUGUI yang ingin diubah teksnya
    public int l;
    private int m;
    private int n;

    void Start()
    {
        m = 0;
        // Pastikan objek textMeshProComponent telah ditetapkan sebelum menggunakannya
        if (textMeshProComponent == null)
        {
            Debug.LogError("Error: TextMeshProUGUI component is not set! Please assign a TextMeshProUGUI component.");
        }

        // Contoh penggunaan saat Start
        //SetTextDynamically("123");
    }
    public void ProcessLValue(int lValue)
    {
        l = lValue;
        VerifL();
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    private void VerifL()
    {
        if(l == 2)
        {
            n = 20;
            m = m + n;
            l = 0;
        }
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
    private void Update()
    {
        ProcessLValue(l);
        SetTextDynamically(m.ToString());

    }
}
