using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditTextRound : MonoBehaviour
{
    public TextMeshProUGUI textMeshProComponent; // Objek TextMeshProUGUI yang ingin diubah teksnya
    private int l;
    private int m;
    public int n;

    void Start()
    {
        m = 0;
        // Pastikan objek textMeshProComponent telah ditetapkan sebelum menggunakannya
        if (textMeshProComponent == null)
        {
            Debug.LogError("Error: TextMeshProUGUI component is not set! Please assign a TextMeshProUGUI component.");
        }

        // Contoh penggunaan saat Start
        
    }
    public void ProcessNValue(int nValue)
    {
        n = nValue;
        VerifN();
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    private void VerifN()
    {
        if (n == 2)
        {
            l = 1;
            m = m + l;
            n = 0;
        }
    }
    private void FixM()
    {
        if (m > 121)
        {
            m = m - 121;
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
        ProcessNValue(n);
        //FixM();
        SetTextDynamically(m.ToString());

    }
}
