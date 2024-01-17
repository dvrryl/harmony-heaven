using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamerecipient : MonoBehaviour
{
    public static Gamerecipient instance; // Menjadikan instance sebagai singleton
    public GameObject[] characters;
    public int characterIndex;

    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedCharacterIndex"))
        {
            // Baca indeks karakter yang dipilih dari PlayerPrefs
            characterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");
        }
        // Ambil data karakter yang dipilih dari kode pertama
        UpdateCharacter();
    }

    void Awake()
    {
        // Membuat instance singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        // Tidak perlu mengambil currentIndex dari ChooseCharacter di sini
    }

    // Menghapus fungsi InstantiateCharacter()
    //public void InstantiateCharacter()
    //{
    //     Instantiate(characters[characterIndex], transform.position, Quaternion.identity);
    //}

    // Menambahkan fungsi UpdateCharacter()
    public void UpdateCharacter()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == characterIndex)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
    }
}