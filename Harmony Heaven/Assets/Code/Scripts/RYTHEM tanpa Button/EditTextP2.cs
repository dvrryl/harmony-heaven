using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditTextP2 : MonoBehaviour
{
    public TextMeshProUGUI textMeshProComponent; // Objek TextMeshProUGUI yang ingin diubah teksnya
    private int l;
    public int m;
    private int n;

    void Start()
    {
        l = 0;
        // Pastikan objek textMeshProComponent telah ditetapkan sebelum menggunakannya
        if (textMeshProComponent == null)
        {
            Debug.LogError("Error: TextMeshProUGUI component is not set! Please assign a TextMeshProUGUI component.");
        }

        // Contoh penggunaan saat Start
        
    }
    public void ProcessMValue(int mValue)
    {
        m = mValue;
        VerifM();
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    private void VerifM()
    {
        if (m == 2)
        {
            n = 20;
            l = l + n;
            m = 0;
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
        ProcessMValue(m);
        SetTextDynamically(l.ToString());

    }
}
