using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacter1 : MonoBehaviour
{
    public GameObject[] characters; // Array untuk menyimpan prefabs karakter
    //public Gamerecipient gameplayController;
    public Button nextButton;
    public Button backButton;
    public Button playButton;
    public int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(NextCharacter);
        backButton.onClick.AddListener(PreviousCharacter);
        playButton.onClick.AddListener(PlayGame);
    }

    void NextCharacter()
    {
        currentIndex++;
        if (currentIndex >= characters.Length)
        {
            currentIndex = 0;
        }
        UpdateCharacter();
    }

    void PreviousCharacter()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = characters.Length - 1;
        }

        UpdateCharacter();
    }

    void UpdateCharacter()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == currentIndex)
            {
                characters[i].SetActive(true);
                Debug.Log("Activated Character Prefab with Index: " + currentIndex);
            }
            else
            {
                characters[i].SetActive(false);
                Debug.Log("false Character Prefab with Index: " + currentIndex);
            }

        }
    }

    void PlayGame()
    {
        // Kirim index karakter yang dipilih hanya ke kode GameplayController yang sudah diassign
        //gameplayController.SetCharacterIndex(currentIndex);
        // Menyimpan indeks karakter yang dipilih ke PlayerPrefs
        PlayerPrefs.SetInt("SelectedCharacterIndex1", currentIndex);
        PlayerPrefs.Save();

        // Pindah ke scene berikutnya (ganti "YourNextScene" dengan nama scene yang diinginkan)
        SceneManager.LoadScene("Gameplay");
    }
}