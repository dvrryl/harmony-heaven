using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressConfirm : MonoBehaviour
{
    public int A = 0;
    public FixedHierarchyController pelayer1;
    public FixedHierarchyController1 pelayer2;

    // Menggunakan array sederhana untuk menyimpan urutan KeyCode yang diharapkan
    public KeyCode[] expectedKeyCodeSequence = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private KeyCode[] currentInputSequence = new KeyCode[0];

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
        // Menggunakan array sederhana untuk menyimpan urutan KeyCode yang diinput
        List<KeyCode> tempList = new List<KeyCode>(currentInputSequence);
        tempList.Add(input);
        currentInputSequence = tempList.ToArray();

        // Debugging: Cetak urutan input saat ini
        string currentSequenceStr = string.Join(", ", currentInputSequence);
        Debug.Log("Urutan Input Saat Ini: " + currentSequenceStr);

        // Debugging: Cetak urutan yang diharapkan
        string expectedSequenceStr = string.Join(", ", expectedKeyCodeSequence);
        Debug.Log("Urutan yang Diharapkan: " + expectedSequenceStr);

        // Cetak jumlah urutan input dan yang diharapkan
        Debug.Log("Jumlah Urutan Input: " + currentInputSequence.Length);
        Debug.Log("Jumlah Urutan Diharapkan: " + expectedKeyCodeSequence.Length);

        // Memverifikasi apakah jumlah urutan input dan yang diharapkan sudah sama
        if (currentInputSequence.Length == expectedKeyCodeSequence.Length)
        {
            bool isCorrectSequence = CheckSequence(currentInputSequence, expectedKeyCodeSequence);
            Debug.Log("Urutan Benar? " + isCorrectSequence);

            if (isCorrectSequence)
            {
                A = 1;
                // Jika benar, kembali ke langkah 1 dengan membersihkan `currentInputSequence`.
                currentInputSequence = new KeyCode[0];
                Debug.Log("Urutan Benar! Resetting...");
                if (OnCorrectSequence != null)
                {
                    OnCorrectSequence();
                }
                currentInputSequence = new KeyCode[0];
            }
            else
            {
                A = 0;
                // Jika salah, matikan hirarki objek yang dikendalikan
                Debug.Log("Urutan Salah! Matikan objek-objek...");
                pelayer1.ProcessFValue(2);
                pelayer2.ProcessFValue(2);
                Debug.Log("f = 2");
                currentInputSequence = new KeyCode[0];
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