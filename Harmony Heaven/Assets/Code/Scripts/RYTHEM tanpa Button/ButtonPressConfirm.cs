using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressConfirm : MonoBehaviour
{
    public KeyCodeConfirmation keyCodeConfirmation; // Referensi ke script KeyCodeConfirmation
    private List<KeyCode> currentInputSequence = new List<KeyCode>(); // Untuk menyimpan input yang diterima
    private List<GameObject> objectsToControl = new List<GameObject>(); // Objek-objek yang akan dikontrol
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;

    private void Start()
    {
        if (keyCodeConfirmation != null)
        {
            // Akses objek-objek yang akan dikontrol dari KeyCodeConfirmation
            objectsToControl = keyCodeConfirmation.GetObjectsToControl();
        }
        else
        {
            Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
        }
    }

    private void Update()
    {
        if (keyCodeConfirmation != null)
        {
            // Loop melalui setiap kode tombol yang ditemukan oleh KeyCodeConfirmation
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
        // Menyatakan input yang diterima
        currentInputSequence.Add(input);
        
        // Menyatakan urutan key code yang seharusnya ditekan
        List<KeyCode> expectedSequence = GetExpectedSequence();
        
        // Debugging: Cetak urutan input saat ini dan urutan yang diharapkan
        string currentSequenceStr = string.Join(", ", currentInputSequence);
        string expectedSequenceStr = string.Join(", ", expectedSequence);
        Debug.Log("Urutan Input Saat Ini: " + currentSequenceStr);
        Debug.Log("Urutan yang Diharapkan: " + expectedSequenceStr);

        // Memverifikasi apakah input yang diterima sesuai dengan urutan kode tombol yang seharusnya ditekan
        bool isCorrectSequence = CheckSequence(currentInputSequence, expectedSequence);
        Debug.Log("Urutan Benar? " + isCorrectSequence);

        if (isCorrectSequence)
        {
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
            // Jika salah, matikan hirarki objek yang dikendalikan
            DeactivateObjects();
            Debug.Log("Urutan Salah! Matikan objek-objek...");
        }
    }

    private List<KeyCode> GetExpectedSequence()
    {
        // Anda perlu mengimplementasikan logika untuk mendapatkan urutan key code yang sesuai
        // Contoh sederhana: Urutan WASD
        return new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
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
        foreach (GameObject obj in objectsToControl)
        {
            obj.SetActive(false);
        }
    }
}