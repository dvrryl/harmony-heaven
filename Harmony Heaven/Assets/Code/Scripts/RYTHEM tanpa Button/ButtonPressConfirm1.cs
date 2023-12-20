using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressConfirm1 : MonoBehaviour
{
    public int A = 0;
    public FixedHierarchyController pelayer1;
    public FixedHierarchyController1 pelayer2;
    private List<KeyCode> expectedKeyCodeSequence = new List<KeyCode>(); // Urutan key code yang diharapkan
    private List<KeyCode> currentInputSequence = new List<KeyCode>(); // Urutan key code yang sedang diinput
    public EditTextP2 score2;
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;

    private void Start()
    {
        // Inisialisasi expectedKeyCodeSequence, misalnya dengan urutan WASD
        expectedKeyCodeSequence = new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    }

    private void Update()
    {
        // Loop melalui setiap kode tombol yang diharapkan
        foreach (KeyCode expectedKeyCode in expectedKeyCodeSequence)
        {
            // Jika kode tombol diharapkan ditekan, verifikasi input
            if (Input.GetKeyDown(expectedKeyCode))
            {
                Debug.Log("Input diterima: " + expectedKeyCode);
                VerifyInput(expectedKeyCode);
            }
        }
    }
    public void SetExpectedKeyCodeSequence(List<KeyCode> sequence)
    {
        expectedKeyCodeSequence = sequence;
        currentInputSequence.Clear();
    }
    public void Reset()
    {
        currentInputSequence.Clear();
        expectedKeyCodeSequence.Clear();
    }

    private void VerifyInput(KeyCode input)
    {
        // Menyatakan input yang diterima
        currentInputSequence.Add(input);

        // Debugging: Cetak urutan input saat ini
        string currentSequenceStr = string.Join(", ", currentInputSequence);
        Debug.Log("Urutan Input Saat Ini: " + currentSequenceStr);

        // Debugging: Cetak urutan yang diharapkan
        string expectedSequenceStr = string.Join(", ", expectedKeyCodeSequence);
        Debug.Log("Urutan yang Diharapkan: " + expectedSequenceStr);

        // Cetak jumlah urutan input dan yang diharapkan
        Debug.Log("Jumlah Urutan Input: " + currentInputSequence.Count);
        Debug.Log("Jumlah Urutan yang Diharapkan: " + expectedKeyCodeSequence.Count);

        // Jika jumlah urutan input dan yang diharapkan sudah sama, lanjutkan ke perbandingan
        if (currentInputSequence.Count == expectedKeyCodeSequence.Count)
        {
            // Mengubah expectedSequenceStr dan currentSequenceStr menjadi array karakter
            char[] expectedSequenceArray = expectedSequenceStr.ToCharArray();
            char[] currentSequenceArray = currentSequenceStr.ToCharArray();

            // Membandingkan setiap elemen array
            bool isCorrectSequence = true;

            // Memverifikasi apakah panjang array sama
            for (int i = 0; i < expectedSequenceArray.Length; i++)
            {
                if (expectedSequenceArray[i] != currentSequenceArray[i])
                {
                    isCorrectSequence = false;
                    break; // Jika ada perbedaan, hentikan loop
                }
            }

            if (isCorrectSequence)
            {
                A = 1;
                score2.ProcessMValue(2);
                pelayer1.ProcessDValue(2);
                // Jika benar, kembali ke langkah 1 dengan membersihkan `currentInputSequence`.
                currentInputSequence.Clear();
                expectedKeyCodeSequence.Clear();
                Debug.Log("Urutan Benar! Resetting...");
                if (OnCorrectSequence != null)
                {
                    OnCorrectSequence();
                }
            }
            else
            {
                A = 0;
                // Jika salah, matikan hirarki objek yang dikendalikan
                Debug.Log("Urutan Salah! Matikan objek-objek...");
                //pelayer2.ProcessEValue(2);
                pelayer1.ProcessEValue(2);
                Debug.Log("e = 2");
                currentInputSequence.Clear();
                expectedKeyCodeSequence.Clear();
            }
        }
    }

    // Metode untuk mengatur urutan key code yang diharapkan
    

    private void DeactivateObjects()
    {
        // Matikan hirarki objek yang dikendalikan
    }
}