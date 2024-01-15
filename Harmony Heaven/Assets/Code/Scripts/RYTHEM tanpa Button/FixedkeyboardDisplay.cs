using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedkeyboardDisplay : MonoBehaviour
{
    public Image[] imageComponents;
    public Sprite[] imageSprites;
    private FixedKeyCodeKeyboard Rythem1;
    private FixedKeyCodeKeyboard1 Rythem2;
    public int h;

    private void Start()
    {
        h = 0;
        Rythem1= GameObject.Find("RythemDisplay").GetComponent<FixedKeyCodeKeyboard>();
        Rythem2 = GameObject.Find("RythemDisplay2").GetComponent<FixedKeyCodeKeyboard1>();
        SetSpritesRandomly(); // Ganti pemanggilan ke metode yang menetapkan sprite secara acak.
    }
    public void ProcessHValue(int hValue)
    {
        h = hValue; // Memperbarui nilai 'h'
        
        // Memeriksa apakah nilai 'h' sama dengan 2
        
    }
    public void SendValueToOtherScript()
    {
        // Panggil metode di Script B dan kirimkan nilai i sebagai parameter
        Rythem1.ReceiveValue(2);
        Rythem2.ReceiveValue(2);
        
    }

    // Metode Update dipanggil setiap frame
    private void Update()
    {
        ProcessHValue(h); // Memanggil metode untuk memproses nilai 'h' setiap frame
        if (h == 2)
        {
            h = 0;
            SendValueToOtherScript();
            SetSpritesRandomly(); // Jika 'h' sama dengan 2, mengatur ulang sprite secara acak
        }
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
            //Debug.LogError("Jumlah imageComponents tidak sesuai dengan jumlah imageSprites. Sesuaikan elemen-elemen ini dengan benar.");
        }
    }
}