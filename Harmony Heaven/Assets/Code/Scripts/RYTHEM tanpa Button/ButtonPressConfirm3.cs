using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressConfirm3 : MonoBehaviour
{
    public int A = 0;
    public FixedHierarchyController pelayer1;
    public FixedHierarchyController1 pelayer2;
    public EditTextP1 score1;

    // Menggunakan array sederhana untuk menyimpan urutan KeyCode yang diharapkan
    public KeyCode[] expectedKeyCodeSequence = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private List<KeyCode> currentInputSequence = new List<KeyCode>();

    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;
    public KeyCodeConfirmation keyCodeConfirmation;

    private void Start()
    {
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
        if (keyCodeConfirmation != null)
        {
            for (int i = 0; i < keyCodeConfirmation.fixedkeyCodeKeyboard.keyboardCodes.Length; i++)
            {
                KeyCode expectedKeyCode = keyCodeConfirmation.fixedkeyCodeKeyboard.keyboardCodes[i];

                if (Input.GetKeyDown(expectedKeyCode))
                {
                    Debug.Log("Input diterima: " + expectedKeyCode);
                    VerifyInput(expectedKeyCode);
                }
            }
        }
        else
        {
            Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
        }
    }

    private void VerifyInput(KeyCode input)
    {
        if (currentInputSequence.Count < expectedKeyCodeSequence.Length)
        {
            // Cek input dengan kode yang diharapkan pada index yang sesuai
            if (input == expectedKeyCodeSequence[currentInputSequence.Count])
            {
                // Jika benar, tambahkan ke dalam currentInputSequence
                currentInputSequence.Add(input);
                Debug.Log("Input Benar: " + input);
            }
            else
            {
                // Jika salah, keluar debug input salah
                Debug.Log("Input Salah: " + input);
            }
        }

        // Jika jumlah currentInputSequence sudah mencapai panjang expectedKeyCodeSequence
        if (currentInputSequence.Count == expectedKeyCodeSequence.Length)
        {
            bool isCorrectSequence = CheckSequence(currentInputSequence.ToArray(), expectedKeyCodeSequence);
            Debug.Log("Urutan Benar? " + isCorrectSequence);

            if (isCorrectSequence)
            {
                A = 1;
                score1.ProcessLValue(2);
                // Jika benar, kembali ke langkah 1 dengan membersihkan `currentInputSequence`.
                currentInputSequence.Clear();
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
                pelayer1.ProcessFValue(2);
                //pelayer2.ProcessFValue(2);
                Debug.Log("f = 2");
                currentInputSequence.Clear();
            }
        }
    }

    public void SetExpectedKeyCodeSequence(List<KeyCode> sequence)
    {
        expectedKeyCodeSequence = sequence.ToArray();
    }

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

    private void DeactivateObjects()
    {
        // Matikan hirarki objek yang dikendalikan
    }
}