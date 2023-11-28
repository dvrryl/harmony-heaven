using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject RythemDisplay;
    public GameObject RythemDisplay1;

    private float timestampPlayer1;
    private float timestampPlayer2;

    public int B; // Menambah variabel B

    // Event untuk memberi tahu bahwa urutan benar dicapai oleh Player 1
    public delegate void CorrectSequencePlayer1Action();
    public static event CorrectSequencePlayer1Action OnCorrectSequencePlayer1;

    // Event untuk memberi tahu bahwa urutan benar dicapai oleh Player 2
    public delegate void CorrectSequencePlayer2Action();
    public static event CorrectSequencePlayer2Action OnCorrectSequencePlayer2;

    void Start()
    {
        // Berlangganan event dari kedua ButtonPressConfirm
        ButtonPressConfirm.OnCorrectSequence += HandleCorrectSequencePlayer1;
        ButtonPressConfirm1.OnCorrectSequence += HandleCorrectSequencePlayer2;
    }

    void HandleCorrectSequencePlayer1()
    {
        timestampPlayer1 = Time.time;
        Debug.Log("Player 1 A: " + RythemDisplay.GetComponent<ButtonPressConfirm>().A + " - Waktu: " + timestampPlayer1);

        // Lakukan verifikasi atau logika lainnya untuk pemain 1
        CheckAndDeactivatePlayers(timestampPlayer1, RythemDisplay, RythemDisplay1);

        // Panggil event OnCorrectSequencePlayer1
        if (OnCorrectSequencePlayer1 != null)
        {
            OnCorrectSequencePlayer1();
        }
    }

    void HandleCorrectSequencePlayer2()
    {
        timestampPlayer2 = Time.time;
        Debug.Log("Player 2 A: " + RythemDisplay1.GetComponent<ButtonPressConfirm1>().A + " - Waktu: " + timestampPlayer2);

        // Lakukan verifikasi atau logika lainnya untuk pemain 2
        CheckAndDeactivatePlayers(timestampPlayer2, RythemDisplay1, RythemDisplay);

        // Panggil event OnCorrectSequencePlayer2
        if (OnCorrectSequencePlayer2 != null)
        {
            OnCorrectSequencePlayer2();
        }
    }

    void CheckAndDeactivatePlayers(float timestamp, GameObject winner, GameObject loser)
    {
        // Lakukan pengecekan apakah pemain ini yang pertama kali mencapai urutan benar
        if (IsWinner(timestamp))
        {
            B = winner.name == "RythemDisplay" ? 1 : -1; // Menentukan nilai B berdasarkan nama winner
            Debug.Log("Urutan benar dicapai oleh " + winner.name + ". Mematikan objek " + loser.name + "...");
            Debug.Log("Nilai B yang dikirim: " + B); // Menampilkan nilai B dalam debug
            loser.SetActive(false);
        }
    }

    bool IsWinner(float timestamp)
    {
        // Lakukan perbandingan waktu untuk menentukan pemenang
        return timestamp == timestampPlayer1 || timestamp == timestampPlayer2;
    }
}