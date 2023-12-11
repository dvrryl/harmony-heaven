using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedKeyCodeKeyboard : MonoBehaviour
{
    public FixedkeyboardDisplay keyboardDisplay;
    public KeyCode[] keyboardCodes;
    private KeyCode[] defaultKeyboardCodes = new KeyCode[5] { KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.S, KeyCode.F };
    public int i;
    public KeyCodeConfirmation pelayer1;

    private void Start()
    {
        keyboardDisplay = GetComponent<FixedkeyboardDisplay>();

        if (keyboardDisplay != null && keyboardDisplay.imageSprites != null)
        {
            int numberOfSprites = keyboardDisplay.imageSprites.Length;

            if (keyboardCodes == null || keyboardCodes.Length != numberOfSprites)
            {
                InitializeKeyboardCodes(numberOfSprites);
            }
        }
        else
        {
            Debug.LogError("Script FixedkeyboardDisplay1 atau imageSprites tidak ditemukan atau belum diinisialisasi.");
        }
    }
    
    
    private void InitializeKeyboardCodes(int numberOfSprites)
    {
        keyboardCodes = new KeyCode[numberOfSprites];
        //Debug.Log("masuk ke InitializeKeyboardCodes");

        for (int i = 0; i < numberOfSprites; i++)
        {
            // Membaca nama sprite
            string spriteName = keyboardDisplay.imageSprites[i].name;
            //Debug.Log("masuk ke string spriteName");

            // Menetapkan KeyCode berdasarkan nama sprite
            switch (spriteName)
            {
                case "ArrowKey_0":
                    keyboardCodes[i] = KeyCode.W;
                    break;
                case "ArrowKey_2":
                    keyboardCodes[i] = KeyCode.A;
                    break;
                case "ArrowKey_3":
                    keyboardCodes[i] = KeyCode.S;
                    break;
                case "ArrowKey_1":
                    keyboardCodes[i] = KeyCode.D;
                    break;
                default:
                    // Default KeyCode jika tidak ada kecocokan
                    keyboardCodes[i] = defaultKeyboardCodes[i];
                    break;
            }
        }
    }
    public void ReceiveValue(int value)
    {
        i = value;
        // Lakukan sesuatu dengan nilai yang diterima
        //Debug.Log("Received value in Script B: " + i);
        if (i == 2)
        {
            //Debug.Log("Received value in Script i: " + i);
            ResetScript(); // Jika 'h' sama dengan 2, mengatur ulang sprite secara acak
            //Debug.Log("melakukan reset");
            i = 0;
            pelayer1.ProcessJValue(2);
        }
    }
    public void ResetScript()
    {
        InitializeKeyboardCodes(keyboardDisplay.imageSprites.Length);
    }
    private void Update()
    {
        ReceiveValue(i);
    }
}