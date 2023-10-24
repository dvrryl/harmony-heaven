using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressConfirm1 : MonoBehaviour
{
    public KeyCodeConfirmation1 keyCodeConfirmation1; // Referensi ke script KeyCodeConfirmation1
    private List<KeyCode> currentInputSequence = new List<KeyCode>(); // Untuk menyimpan input yang diterima
    private List<GameObject> objectsToControl = new List<GameObject>(); // Objek-objek yang akan dikontrol

    private void Start()
    {
        if (keyCodeConfirmation1 != null)
        {
            // Akses objek-objek yang akan dikontrol dari KeyCodeConfirmation1
            objectsToControl = keyCodeConfirmation1.GetObjectsToControl();
        }
        else
        {
            Debug.LogError("Script KeyCodeConfirmation1 tidak ditemukan.");
        }
    }

    private void Update()
    {
        if (keyCodeConfirmation1 != null)
        {
            // Loop melalui setiap kode tombol yang ditemukan oleh KeyCodeConfirmation1
            for (int i = 0; i < keyCodeConfirmation1.fixedkeyCodeKeyboard1.keyboardCodes.Length; i++)
            {
                KeyCode expectedKeyCode = keyCodeConfirmation1.fixedkeyCodeKeyboard1.keyboardCodes[i];

                if (Input.GetKeyDown(expectedKeyCode))
                {
                    Debug.Log("Input diterima: " + expectedKeyCode);
                    VerifyInput(expectedKeyCode);
                }
            }
        }
        else
        {
            Debug.LogError("Script KeyCodeConfirmation1 tidak ditemukan.");
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