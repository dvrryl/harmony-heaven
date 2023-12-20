using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressConfirm4 : MonoBehaviour
{
    private int t = 0;
    private List<KeyCode> expectedKeyCodeSequence = new List<KeyCode>();
    private List<KeyCode> currentInputSequence = new List<KeyCode>();
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;
    public KeyCodeConfirmation1 keyCodeConfirmation1;

    // Warna ketika benar
    public Color correctColor = new Color(1f, 0.91f, 0f); // #FFE900

    // Warna ketika salah
    public Color wrongColor = new Color(1f, 0f, 0f); // #FF0000
    public Image[] imageComponents;
    private Color defaultColor = new Color(1f, 1f, 1f);

    private void Start()
    {
        // Inisialisasi expectedKeyCodeSequence, misalnya dengan urutan WASD
        expectedKeyCodeSequence = new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    }

    private void Update()
    {
        // Pengecekan dengan foreach
        foreach (KeyCode expectedKeyCode in expectedKeyCodeSequence)
        {
            if (Input.GetKeyDown(expectedKeyCode))
            {
               // Debug.Log("Input diterima: " + expectedKeyCode);
                VerifyInput(expectedKeyCode);
            }
        }
        if (t == 1)
        {
            t = 3;
            ResetAllColorsData();
            expectedKeyCodeSequence.Clear();
            currentInputSequence.Clear();
        }
        if (t == 2)
        {
            t = 3;
            ResetAllColorsData();
            expectedKeyCodeSequence.Clear();
            currentInputSequence.Clear();
        }
        // Pengecekan menggunakan perbandingan string
        CheckStringComparison();

        // ... (existing logic)
    } 
    
    // Metode untuk memverifikasi input tombol kunci
    private void VerifyInput(KeyCode input)
    {
       // Debug.Log("Urutan yang Diharapkan Sebelum Verifikasi: " + string.Join(", ", expectedKeyCodeSequence));
        //Debug.Log("Jumlah Urutan Input Sebelum Verifikasi: " + currentInputSequence.Count);

        if (currentInputSequence.Count < expectedKeyCodeSequence.Count)
        {
            if (input == expectedKeyCodeSequence[currentInputSequence.Count])
            {
                currentInputSequence.Add(input);
               // Debug.Log("Input Benar: " + input);
                ChangeSingleColorBenar();
                //Debug.Log("Jumlah Urutan Input Setelah Penambahan Input: " + currentInputSequence.Count);
            }
            else
            {
                //Debug.Log("Input Salah: " + input);
                int wrongIndex = currentInputSequence.Count; // Index yang salah adalah panjang sebelumnya
                ChangeSingleColor(wrongIndex, wrongColor);
                currentInputSequence.Capacity = currentInputSequence.Count + 1;
                currentInputSequence.Add(input);

            }
        }

        //Debug.Log("Jumlah Urutan Input Setelah Verifikasi: " + currentInputSequence.Count);
    }

    // Metode untuk mendapatkan indeks yang tidak sesuai dalam urutan tombol kunci
    private int FindWrongIndex(List<KeyCode> current, List<KeyCode> expected)
    {
        for (int i = 0; i < current.Count; i++)
        {
            if (current[i] != expected[i])
            {
                return i;
            }
        }
        return -1; // Mengembalikan -1 jika tidak ada indeks yang salah
    }

    // Metode untuk memeriksa apakah urutan tombol kunci benar
    

    // Metode untuk mengatur urutan key code yang diharapkan
    public void SetExpectedKeyCodeSequence(List<KeyCode> sequence)
    {
        ResetAllColorsData();
        expectedKeyCodeSequence = sequence;
        currentInputSequence.Clear();
        ResetAllColorsData();
    }


    // Pengecekan menggunakan perbandingan string
    private void CheckStringComparison()
    {
        if (currentInputSequence.Count == expectedKeyCodeSequence.Count)
        {
            string currentSequenceStr = string.Join(", ", currentInputSequence);
            string expectedSequenceStr = string.Join(", ", expectedKeyCodeSequence);

            if (currentSequenceStr.Equals(expectedSequenceStr))
            {
                Debug.Log("Urutan Benar! Resetting...");
                ResetAllColorsData();
                currentInputSequence.Clear();
                if (OnCorrectSequence != null)
                {
                    OnCorrectSequence();
                }
            }
            else
            {
                ResetAllColorsData();
                currentInputSequence.Clear();
            }
        }
    }

    // Metode untuk mengubah warna satu komponen berdasarkan indeks
    private void ChangeSingleColor(int index, Color color)
    {
        // Memastikan index berada dalam batas array
        if (index >= 0 && index < expectedKeyCodeSequence.Count)
        {
            // Implementasi untuk mengubah warna komponen pada index tertentu
            // Misalnya, jika ada objek UI dengan warna, Anda dapat mengakses komponen warna seperti berikut:
             imageComponents[index].color = color;
        }
    }

    // Metode untuk mengubah warna semua komponen
    private void ChangeColors(Color color)
    {
        // Implementasi untuk mengubah warna semua komponen
        // Misalnya, jika ada objek UI dengan warna, Anda dapat melakukan iterasi seperti berikut:
         foreach (Image imageComponent in imageComponents)
         {
             imageComponent.color = color;
         }
    }

    // Metode untuk mengembalikan semua data warna ke warna default
    private void ResetAllColorsData()
    {
        // Implementasi untuk mengembalikan semua data warna ke warna default
        // Misalnya, jika ada objek UI dengan warna, Anda dapat melakukan iterasi seperti berikut:
         foreach (Image imageComponent in imageComponents)
         {
             imageComponent.color = defaultColor;
         }
    }

    // Metode untuk mengubah warna saat urutan benar
    private void ChangeSingleColorBenar()
    {
        // Implementasi untuk mengubah warna setiap index yang sesuai dengan urutan input benar ke warna #FFE900
        for (int i = 0; i < currentInputSequence.Count; i++)
        {
            if (i < expectedKeyCodeSequence.Count && currentInputSequence[i] == expectedKeyCodeSequence[i])
            {
                ChangeSingleColor(i, correctColor);
            }
        }
    }

    // Pengecekan dengan Input.GetKeyDown di dalam loop
    private void CheckInputInLoop()
    {
        // Implementasi pengecekan dengan Input.GetKeyDown di dalam loop
        // Misalnya, jika Anda memiliki array kode tombol yang diharapkan, Anda dapat melakukan iterasi seperti berikut:
         for (int i = 0; i < expectedKeyCodeSequence.Count; i++)
         {
             KeyCode expectedKeyCode = expectedKeyCodeSequence[i];
             if (Input.GetKeyDown(expectedKeyCode))
             {
                 Debug.Log("Input diterima: " + expectedKeyCode);
                 VerifyInput(expectedKeyCode);
             }
         }
    }
}
