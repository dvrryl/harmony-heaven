using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreExel : MonoBehaviour
{
    private static ScoreExel instance;

    public static ScoreExel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreExel>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<ScoreExel>();
                    singletonObject.name = typeof(ScoreExel).ToString() + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);
                }
            }

            return instance;
        }
    }

    public string filePath = "Assets/Data/Scores.xls";  // Sesuaikan dengan lokasi file Excel Anda

    public void WriteToExcel(int score)
    {
        // Membaca nilai lama dari file Excel
        int oldScore = ReadFromExcel();

        // Menambahkan nilai baru ke nilai lama
        int newScore = oldScore + score;

        // Membuat string CSV dengan satu baris berisi nilai baru
        string csvContent = "Score\n" + newScore;

        // Menulis string CSV ke file Excel
        File.WriteAllText(filePath, csvContent);

        Debug.Log("Score Added to Excel: " + score);
    }

    // Membaca nilai lama dari file Excel
    private int ReadFromExcel()
    {
        int oldScore = 0;

        if (File.Exists(filePath))
        {
            // Membaca seluruh isi file Excel
            string csvContent = File.ReadAllText(filePath);

            // Memecah isi file menjadi baris
            string[] lines = csvContent.Split('\n');

            // Membaca nilai lama (baris kedua karena baris pertama adalah header)
            if (lines.Length >= 2 && int.TryParse(lines[1], out oldScore))
            {
                Debug.Log("Old Score Read from Excel: " + oldScore);
            }
        }

        return oldScore;
    }
}
