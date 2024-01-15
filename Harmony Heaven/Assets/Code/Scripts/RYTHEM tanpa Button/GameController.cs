using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int B = 0; // Menambah variabel B
    public GameObject RythemDisplay;
    public GameObject RythemDisplay1;
    public PlayerCoba1 pc1;
    public PlayerCoba2 pc2;
    public FixedHierarchyController die;
    private float timestampPlayer1;
    private float timestampPlayer2;

    // Event untuk memberi tahu bahwa urutan benar dicapai oleh Player 1
    //public delegate void CorrectSequencePlayer1Action();
    //public static event CorrectSequencePlayer1Action OnCorrectSequencePlayer;

    void Start()
    {
        
        // Berlangganan event dari kedua ButtonPressConfirm
        ButtonPressConfirm.OnCorrectSequence += HandleCorrectSequencePlayer1;
        ButtonPressConfirm1.OnCorrectSequence += HandleCorrectSequencePlayer2;
    }

    void HandleCorrectSequencePlayer1()
    {
        timestampPlayer1 = Time.time;
        //Debug.Log("Player 1 A: " + RythemDisplay.GetComponent<ButtonPressConfirm>().A + " - Waktu: " + timestampPlayer1);
        B = RythemDisplay.GetComponent<ButtonPressConfirm>().A * 2;
        // Lakukan verifikasi atau logika lainnya untuk pemain 1
        //Debug.Log("ada di gamecontrol 1");
        die.ProcessDValue(1);
        CheckAndDeactivatePlayers(timestampPlayer1, RythemDisplay, RythemDisplay1);
        //Debug.Log("ada di gamecontrol12");
        pc2.ProcessCValue(1);
        //Debug.Log("Update - d is 1");

    }

    void HandleCorrectSequencePlayer2()
    {
        timestampPlayer2 = Time.time;
        //Debug.Log("Player 2 A: " + RythemDisplay1.GetComponent<ButtonPressConfirm1>().A + " - Waktu: " + timestampPlayer2);
        B = RythemDisplay.GetComponent<ButtonPressConfirm>().A * 3;
        // Lakukan verifikasi atau logika lainnya untuk pemain 2
        //Debug.Log("ada di gamecontrol2");
        die.ProcessDValue(1);
        CheckAndDeactivatePlayers(timestampPlayer2, RythemDisplay1, RythemDisplay);
        //Debug.Log("ada di gamecontrol21");
        pc1.ProcessBValue(1);
        //Debug.Log("Update - d is 1");


        // Panggil event OnCorrectSequencePlayer2

    }

    void CheckAndDeactivatePlayers(float timestamp, GameObject winner, GameObject loser)
    {
        // Lakukan pengecekan apakah pemain ini yang pertama kali mencapai urutan benar
        if (IsWinner(timestamp))
        {
            //B = winner.name == "RythemDisplay" ? 1 : -1; // Menentukan nilai B berdasarkan nama winner
            //Debug.Log("Urutan benar dicapai oleh " + winner.name + ". Mematikan objek " + loser.name + "...");
            //Debug.Log("Nilai B yang dikirim: " + B); // Menampilkan nilai B dalam debug
            loser.SetActive(false);
        }
    }

    bool IsWinner(float timestamp)
    {
        // Lakukan perbandingan waktu untuk menentukan pemenang
        return timestamp == timestampPlayer1 || timestamp == timestampPlayer2;
    }
}