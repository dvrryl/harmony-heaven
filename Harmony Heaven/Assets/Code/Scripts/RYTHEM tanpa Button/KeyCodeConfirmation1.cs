using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeConfirmation1 : MonoBehaviour
{
    public FixedkeyboardDisplay fixedkeyboardDisplay; // Referensi ke script KeyboardDisplay
    public FixedKeyCodeKeyboard1 fixedkeyCodeKeyboard1; // Referensi ke script KeyCodeKeyboard

    private List<GameObject> objectsToControl = new List<GameObject>(); // Objek-objek yang akan dikontrol

    void Start()
    {
        // Panggil fungsi CompileConfirmation dengan penundaan 1 detik.
        Invoke("CompileConfirmation", 1f);
    }

    void CompileConfirmation()
    {
        if (fixedkeyboardDisplay != null && fixedkeyCodeKeyboard1 != null)
        {
            Debug.Log("Mendapatkan informasi ImageComponent...");
            int numberOfImageComponents = fixedkeyboardDisplay.imageComponents.Length;
            Debug.Log("Jumlah ImageComponent: " + numberOfImageComponents);

            for (int i = 0; i < numberOfImageComponents; i++)
            {
                Image imageComponent = fixedkeyboardDisplay.imageComponents[i];
                Sprite imageSprite = imageComponent.sprite;

                Debug.Log("Mengecek ImageSprite pada ImageComponent " + i + "...");
                string imageSpriteName = FindSpriteName(imageSprite);
                if (!string.IsNullOrEmpty(imageSpriteName))
                {
                    Debug.Log("Nama Sprite: " + imageSpriteName);
                    int spriteIndex = FindSpriteIndex(imageSpriteName);
                    if (spriteIndex != -1)
                    {
                        KeyCode keyCode = FindKeyCode(spriteIndex);
                        Debug.Log("ImageSprite " + i + " - Keycode: " + keyCode);
                    }
                    else
                    {
                        Debug.LogWarning("Tidak ada KeyCode yang sesuai untuk ImageSprite " + i);
                    }
                }
                else
                {
                    Debug.LogWarning("Nama Sprite tidak ditemukan untuk ImageSprite " + i);
                }
            }
        }
        else
        {
            Debug.LogError("Script KeyboardDisplay atau KeyCodeKeyboard tidak ditemukan.");
        }
    }

    private string FindSpriteName(Sprite imageSprite)
    {
        // Kode untuk menemukan nama Sprite dari imageSprite.
        // Gantilah ini dengan logika Anda sendiri.
        return imageSprite.name;
    }

    private int FindSpriteIndex(string spriteName)
    {
        for (int i = 0; i < fixedkeyboardDisplay.imageSprites.Length; i++)
        {
            if (spriteName == fixedkeyboardDisplay.imageSprites[i].name)
            {
                return i;
            }
        }
        return -1; // Jika tidak ditemukan
    }

    private KeyCode FindKeyCode(int spriteIndex)
    {
        if (spriteIndex >= 0 && spriteIndex < fixedkeyCodeKeyboard1.keyboardCodes.Length)
        {
            return fixedkeyCodeKeyboard1.keyboardCodes[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Indeks sprite tidak valid: " + spriteIndex);
            return KeyCode.None; // Kode tombol default jika indeks tidak valid
        }
    }

    // Metode untuk mengembalikan objek-objek yang akan dikontrol
    public List<GameObject> GetObjectsToControl()
    {
        // Anda perlu mengisi daftar objek-objek yang akan dikontrol sesuai dengan kebutuhan Anda
        // Contoh sederhana: Daftar objek yang akan dikontrol adalah objek di bawah script ini
        foreach (Transform child in transform)
        {
            objectsToControl.Add(child.gameObject);
        }
        return objectsToControl;
    }
}