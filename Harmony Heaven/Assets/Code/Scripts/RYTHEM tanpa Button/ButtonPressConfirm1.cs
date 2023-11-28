using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressConfirm1 : MonoBehaviour
{
    private List<KeyCode> expectedKeyCodeSequence = new List<KeyCode>(); // Urutan key code yang diharapkan
    private List<KeyCode> currentInputSequence = new List<KeyCode>(); // Urutan key code yang sedang diinput
    public int A;

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

    private void VerifyInput(KeyCode input)
    {
        // Menyatakan input yang diterima
        currentInputSequence.Add(input);

        // Debugging: Cetak urutan input saat ini dan urutan yang diharapkan
        string currentSequenceStr = string.Join(", ", currentInputSequence);
        string expectedSequenceStr = string.Join(", ", expectedKeyCodeSequence);
        Debug.Log("Urutan Input Saat Ini: " + currentSequenceStr);
        Debug.Log("Urutan yang Diharapkan: " + expectedSequenceStr);

        // Memverifikasi apakah input yang diterima sesuai dengan urutan kode tombol yang seharusnya ditekan
        bool isCorrectSequence = CheckSequence(currentInputSequence, expectedKeyCodeSequence);
        Debug.Log("Urutan Benar? " + isCorrectSequence);

        if (isCorrectSequence)
        {
            A = 1;
            // Jika benar, kembali ke langkah 1 dengan membersihkan `currentInputSequence`.
            currentInputSequence.Clear();
            Debug.Log("Urutan Benar! Resetting...");
        }
        else
        {
            A = 0;
            // Jika salah, matikan hirarki objek yang dikendalikan
            Debug.Log("Urutan Salah! Matikan objek-objek...");
        }
    }

    // Metode untuk mengatur urutan key code yang diharapkan
    public void SetExpectedKeyCodeSequence(List<KeyCode> sequence)
    {
        expectedKeyCodeSequence = sequence;
    }

    private bool CheckSequence(List<KeyCode> current, List<KeyCode> expected)
    {
        if (current.Count != expected.Count)
        {
            return false;
        }

        for (int i = 0; i < current.Count; i++)
        {
            if (current[i] != expected[i])
            {
                return false;
            }
        }

        return true;
    }

    private void DeactivateObjects()
    {
        // Matikan hirarki objek yang dikendalikan
    }
}