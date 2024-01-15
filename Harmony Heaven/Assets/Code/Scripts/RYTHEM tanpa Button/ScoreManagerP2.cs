using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagerP2 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int currentScore = 0;
    public ScoreExel ScoreExcel;

    void Start()
    {
        LoadScore();
        // Membaca langsung nilai dari TextMeshProUGUI saat script dimulai
        //ReadTextMeshProUGUIValue();
        // Jangan reset nilai currentScore di sini
        Debug.Log("Score Manager started. Initial Score: " + currentScore);
    }

    // Fungsi untuk membaca langsung nilai dari TextMeshProUGUI
    private void ReadTextMeshProUGUIValue()
    {
        // Pastikan scoreText tidak null sebelum mencoba membacanya
        if (scoreText != null)
        {
            // Coba mengonversi teks menjadi angka dan tambahkan ke currentScore
            if (int.TryParse(scoreText.text.Replace("Score: ", ""), out int parsedScore))
            {
                currentScore += parsedScore;
            }
            else
            {
                Debug.LogError("Failed to parse TextMeshProUGUI value to integer.");
            }
        }
        else
        {
            Debug.LogError("scoreText is null. Make sure it is assigned in the inspector.");
        }
    }

    // Fungsi untuk membaca langsung nilai dari TextMeshProUGUI dan menambahkan ke currentScore
    public void ReadAndUpdateScoreFromTextMeshProUGUI()
    {
        ReadTextMeshProUGUIValue();
        UpdateScoreText();
        ScoreExcel.WriteToExcel(currentScore);
    }

    // Fungsi untuk mereset nilai currentScore menjadi 0
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreText();
        Debug.Log("Score Reset. Current Score: " + currentScore);
    }

    // Fungsi untuk menambah skor
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        Debug.Log("Score Added: " + scoreToAdd + ". Current Score: " + currentScore);

        // Memanggil fungsi untuk menyimpan skor
        SaveScore();
    }

    // Fungsi untuk menyimpan skor
    public void SaveScore()
    {
        PlayerPrefs.SetInt("ScoreManagerP2_Score", currentScore);
        PlayerPrefs.Save();
        Debug.Log("Score Saved: " + currentScore);
    }

    // Fungsi untuk memuat skor
    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("ScoreManagerP2_Score"))
        {
            int ScoreManagerP2_Score = PlayerPrefs.GetInt("ScoreManagerP2_Score");
            Debug.Log("Score Loaded: " + ScoreManagerP2_Score);
            currentScore = ScoreManagerP2_Score;  // Set currentScore dengan nilai yang di-load
            UpdateScoreText();  // Perbarui tampilan teks skor setelah nilai di-load
        }
    }

    // Fungsi untuk memperbarui tampilan teks skor
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
        Debug.Log("Score Text Updated: " + currentScore);
    }

    // Fungsi yang akan dipanggil saat aplikasi ditutup
    void OnApplicationQuit()
    {
        SaveScore();
        Debug.Log("Application quitting. Score saved: " + currentScore);
    }

    // Fungsi Update() untuk keperluan reset saat tombol "R" ditekan
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ReadAndUpdateScoreFromTextMeshProUGUI();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScore();
        }
    }
}
