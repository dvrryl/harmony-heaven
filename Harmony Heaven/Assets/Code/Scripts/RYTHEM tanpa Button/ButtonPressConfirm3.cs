using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressConfirm3 : MonoBehaviour
{
    // Variabel publik untuk menyimpan nilai A, controller pemain, dan skor pemain
    public int A = 0;
    public FixedHierarchyController pelayer1;
    public FixedHierarchyController1 pelayer2;
    public EditTextP1 score1;

    // Urutan tombol kunci yang diharapkan
    public KeyCode[] expectedKeyCodeSequence = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private List<KeyCode> currentInputSequence = new List<KeyCode>();

    // Event yang dipanggil ketika urutan tombol kunci benar
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;
    public KeyCodeConfirmation keyCodeConfirmation;

    private void Start()
    {
        // Cari objek KeyCodeConfirmation jika belum diinisialisasi
        if (keyCodeConfirmation == null)
        {
            keyCodeConfirmation = FindObjectOfType<KeyCodeConfirmation>();
            if (keyCodeConfirmation == null)
            {
                Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
            }
        }
    }

    private void Update()
    {
        // Periksa apakah objek KeyCodeConfirmation telah diinisialisasi
        if (keyCodeConfirmation != null)
        {
            // Loop melalui tombol kunci yang diharapkan
            for (int i = 0; i < keyCodeConfirmation.fixedkeyCodeKeyboard.keyboardCodes.Length; i++)
            {
                KeyCode expectedKeyCode = keyCodeConfirmation.fixedkeyCodeKeyboard.keyboardCodes[i];

                // Periksa apakah tombol kunci yang diharapkan ditekan
                if (Input.GetKeyDown(expectedKeyCode))
                {
                    Debug.Log("Input diterima: " + expectedKeyCode);
                    VerifyInput(expectedKeyCode);
                }
            }

            // Pindahkan logika pengecekan urutan ke sini
            if (currentInputSequence.Count == expectedKeyCodeSequence.Length)
            {
                bool isCorrectSequence = CheckSequence(currentInputSequence.ToArray(), expectedKeyCodeSequence);
                if (isCorrectSequence)
                {
                    // Urutan input benar
                    Debug.Log("Urutan Benar! Resetting...");
                    A = 1;
                    score1.ProcessLValue(2);
                    currentInputSequence.Clear();
                    if (OnCorrectSequence != null)
                    {
                        OnCorrectSequence();
                    }
                }
                else
                {
                    // Urutan input salah
                    Debug.Log("Urutan Salah! Matikan objek-objek...");
                    A = 0;
                    pelayer1.ProcessFValue(2);
                    currentInputSequence.Clear();
                    Debug.Log("f = 2");
                }
            }
        }
        else
        {
            Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
        }
    }

    // Metode untuk memverifikasi input tombol kunci
    private void VerifyInput(KeyCode input)
    {
        Debug.Log("Urutan yang Diharapkan Sebelum Verifikasi: " + string.Join(", ", expectedKeyCodeSequence));
        Debug.Log("Jumlah Urutan Input Sebelum Verifikasi: " + currentInputSequence.Count);

        if (currentInputSequence.Count < expectedKeyCodeSequence.Length)
        {
            if (input == expectedKeyCodeSequence[currentInputSequence.Count])
            {
                currentInputSequence.Add(input);
                Debug.Log("Input Benar: " + input);
                Debug.Log("Jumlah Urutan Input Setelah Penambahan Input: " + currentInputSequence.Count);
            }
            else
            {
                Debug.Log("Input Salah: " + input);
                currentInputSequence.Add(input);
            }
        }

        Debug.Log("Jumlah Urutan Input Setelah Verifikasi: " + currentInputSequence.Count);
    }

    // Metode untuk mendapatkan indeks yang tidak sesuai dalam urutan tombol kunci
    private string GetMismatchedIndices(KeyCode[] current, KeyCode[] expected)
    {
        List<string> mismatchedIndices = new List<string>();
        for (int i = 0; i < current.Length; i++)
        {
            if (current[i] != expected[i])
            {
                mismatchedIndices.Add(i.ToString());
            }
        }
        return string.Join(", ", mismatchedIndices.ToArray());
    }

    // Metode untuk memeriksa apakah urutan tombol kunci benar
    private bool CheckSequence(KeyCode[] current, KeyCode[] expected)
    {
        if (current.Length != expected.Length)
        {
            return false;
        }

        for (int i = 0; i < current.Length; i++)
        {
            if (current[i] != expected[i])
            {
                return false;
            }
        }

        return true;
    }
}