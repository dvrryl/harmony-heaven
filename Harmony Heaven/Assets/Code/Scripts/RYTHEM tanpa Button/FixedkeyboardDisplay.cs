using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedkeyboardDisplay : MonoBehaviour
{
    public Image[] imageComponents;
    public Sprite[] imageSprites;
    private FixedKeyCodeKeyboard Rythem1;
    public int h;
    public int k;

    private void Start()
    {
        h = 0;
        Rythem1= GameObject.Find("RythemDisplay").GetComponent<FixedKeyCodeKeyboard>();
        SetSpritesRandomly(); // Ganti pemanggilan ke metode yang menetapkan sprite secara acak.
    }
    public void ProcessHValue(int hValue)
    {
        h = hValue; // Memperbarui nilai 'h'
        
        // Memeriksa apakah nilai 'h' sama dengan 2
        if (h == 2)
        {
            SendValueToOtherScript();
            SetSpritesRandomly(); // Jika 'h' sama dengan 2, mengatur ulang sprite secara acak
            h = 0;
        }
    }
    public void SendValueToOtherScript()
    {
        // Panggil metode di Script B dan kirimkan nilai i sebagai parameter
        Rythem1.ReceiveValue(h);
        
    }

    // Metode Update dipanggil setiap frame
    void Update()
    {
        ProcessHValue(h); // Memanggil metode untuk memproses nilai 'h' setiap frame
        SendValueToOtherScript();
    }

    private void SetSpritesRandomly()
    {
        // Pastikan jumlah elemen pada imageComponents sesuai dengan jumlah elemen pada imageSprites.
        if (imageComponents.Length == imageSprites.Length)
        {
            // Buat array baru untuk menyimpan indeks sprite yang sudah diacak.
            int[] randomIndexes = new int[imageSprites.Length];
            for (int i = 0; i < randomIndexes.Length; i++)
            {
                randomIndexes[i] = i;
            }

            // Acak indeks sprite.
            for (int i = 0; i < randomIndexes.Length; i++)
            {
                int temp = randomIndexes[i];
                int randomIndex = Random.Range(i, randomIndexes.Length);
                randomIndexes[i] = randomIndexes[randomIndex];
                randomIndexes[randomIndex] = temp;
            }

            // Tetapkan sprite secara acak ke komponen.
            for (int i = 0; i < imageComponents.Length; i++)
            {
                imageComponents[i].sprite = imageSprites[randomIndexes[i]];
            }
        }
        else
        {
            Debug.LogError("Jumlah imageComponents tidak sesuai dengan jumlah imageSprites. Sesuaikan elemen-elemen ini dengan benar.");
        }
    }
}