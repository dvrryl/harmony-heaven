using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressConfirm3 : MonoBehaviour
{
    // Variabel publik untuk menyimpan nilai A, controller pemain, dan skor pemain
    public int A = 0;
    public FixedHierarchyController pelayer1;
    public FixedHierarchyController1 pelayer2;

    // Urutan tombol kunci yang diharapkan
    public KeyCode[] expectedKeyCodeSequence = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private KeyCode[] currentInputSequence = new KeyCode[0];

    // Event yang dipanggil ketika urutan tombol kunci benar
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;
    public KeyCodeConfirmation keyCodeConfirmation;

    // Warna ketika benar
    public Color correctColor = new Color(1f, 0.91f, 0f); // #FFE900

    // Warna ketika salah
    public Color wrongColor = new Color(1f, 0f, 0f); // #FF0000

    // Menambahkan array imageComponents
    public Image[] imageComponents;
    private Color defaultColor = new Color(1f, 1f, 1f);

    private void Start()
    {
        // Cari objek KeyCodeConfirmation jika belum diinisialisasi
        if (keyCodeConfirmation == null)
        {
            keyCodeConfirmation = FindObjectOfType<KeyCodeConfirmation>();
            if (keyCodeConfirmation == null)
            {
                //Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
            }
        }
    }

    public void SetExpectedKeyCodeSequence(List<KeyCode> sequence)
    {
        ResetAllColorsData();
        expectedKeyCodeSequence = sequence.ToArray();
        currentInputSequence = new KeyCode[0];
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
                    //Debug.Log("Input diterima: " + expectedKeyCode);
                    VerifyInput(expectedKeyCode);
                }
            }

            // Pindahkan logika pengecekan urutan ke sini
            if (currentInputSequence.Length == expectedKeyCodeSequence.Length)
            {
                bool isCorrectSequence = CheckSequence(currentInputSequence, expectedKeyCodeSequence);
                if (isCorrectSequence)
                {
                    // Urutan input benar
                    //Debug.Log("Urutan Benar! Resetting...");
                    A = 1;
                    //ChangeColors(correctColor);
                    ResetAllColorsData();
                    currentInputSequence = new KeyCode[0];
                    if (OnCorrectSequence != null)
                    {
                        OnCorrectSequence();
                    }
                    ResetExpectedKeyCodeSequence();
                }
                else
                {
                    // Urutan input salah
                    //Debug.Log("Urutan Salah! Matikan objek-objek...");
                    A = 0;
                    int wrongIndex = FindWrongIndex(currentInputSequence, expectedKeyCodeSequence);
                    if (wrongIndex != -1)
                    {
                        ChangeSingleColor(wrongIndex, wrongColor);
                    }
                    currentInputSequence = new KeyCode[0];
                    ResetAllColorsData();
                    ResetExpectedKeyCodeSequence();
                }
            }
        }
        else
        {
            //Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
        }
    }
    private void ResetExpectedKeyCodeSequence()
    {
        expectedKeyCodeSequence = new KeyCode[0];
    }
    // Metode untuk memverifikasi input tombol kunci
    private void VerifyInput(KeyCode input)
    {
        //Debug.Log("Urutan yang Diharapkan Sebelum Verifikasi: " + string.Join(", ", expectedKeyCodeSequence));
        //Debug.Log("Jumlah Urutan Input Sebelum Verifikasi: " + currentInputSequence.Length);

        if (currentInputSequence.Length < expectedKeyCodeSequence.Length)
        {
            if (input == expectedKeyCodeSequence[currentInputSequence.Length])
            {
                // Gunakan Array.Resize untuk menambahkan elemen ke array
                System.Array.Resize(ref currentInputSequence, currentInputSequence.Length + 1);
                currentInputSequence[currentInputSequence.Length - 1] = input;

                //Debug.Log("Input Benar: " + input);
                ChangeSingleColorBenar();
                //Debug.Log("Jumlah Urutan Input Setelah Penambahan Input: " + currentInputSequence.Length);
            }
            else
            {
                //Debug.Log("Input Salah: " + input);
                int wrongIndex = currentInputSequence.Length; // Index yang salah adalah panjang sebelumnya
                ChangeSingleColor(wrongIndex, wrongColor); // Mengubah warna langsung pada index yang salah
                // Gunakan Array.Resize untuk menambahkan elemen ke array
                System.Array.Resize(ref currentInputSequence, currentInputSequence.Length + 1);
                currentInputSequence[currentInputSequence.Length - 1] = input;
            }
        }

        //Debug.Log("Jumlah Urutan Input Setelah Verifikasi: " + currentInputSequence.Length);
    }

    // Metode untuk mendapatkan indeks yang tidak sesuai dalam urutan tombol kunci
    private int FindWrongIndex(KeyCode[] current, KeyCode[] expected)
    {
        for (int i = 0; i < current.Length; i++)
        {
            if (current[i] != expected[i])
            {
                return i;
            }
        }
        return -1; // Mengembalikan -1 jika tidak ada indeks yang salah
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

    // Metode untuk mengubah warna satu komponen berdasarkan indeks
    private void ChangeSingleColor(int index, Color color)
    {
        if (index >= 0 && index < imageComponents.Length)
        {
            imageComponents[index].color = color;
        }
    }

    // Metode untuk mengubah warna semua komponen
    private void ChangeColors(Color color)
    {
        foreach (Image imageComponent in imageComponents)
        {
            imageComponent.color = color;
        }
    }
    private void ResetAllColorsData()
    {
        // Mengembalikan semua warna komponen ke warna default
        foreach (Image imageComponent in imageComponents)
        {
            imageComponent.color = defaultColor;
        }
    }
    private void ChangeSingleColorBenar()
    {
        // Mengubah warna setiap index yang sesuai dengan urutan input benar ke warna #FFE900
        for (int i = 0; i < currentInputSequence.Length; i++)
        {
            if (i < expectedKeyCodeSequence.Length && currentInputSequence[i] == expectedKeyCodeSequence[i])
            {
                ChangeSingleColor(i, correctColor);
            }
        }
    }
}