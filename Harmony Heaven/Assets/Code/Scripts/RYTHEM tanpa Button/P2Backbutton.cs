using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class P2Backbutton : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject StartButton2;
    public GameObject BGP2;
    public GameObject BGP1;
    public GameObject P2;
    public GameObject P1;
    public GameObject p1name;
    public GameObject p2name;
    public GameObject P2Back;

    void OnEnable()
    {
        // Mengaitkan metode masuk() dengan event onClick pada tombol
        StartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LoadGameplayScene);
    }

    void OnDisable()
    {
        // Membersihkan event onClick agar tidak menyimpan referensi ganda
        StartButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(LoadGameplayScene);
    }
    private void LoadGameplayScene()
    {
        masuk();
        Debug.Log("Gameplay");
    }

    private void masuk()
    {
        DisableGameObject();
        EnableGameObject();
    }

    public void DisableGameObject()
    {
        // Nonaktifkan kedua game object
        StartButton2.SetActive(false);
        BGP2.SetActive(false);
        P2.SetActive(false);
        P2Back.SetActive(false);
        p2name.SetActive(false);

    }

    public void EnableGameObject()
    {
        // Aktifkan kedua game object
        StartButton.SetActive(true);
        BGP1.SetActive(true);
        P1.SetActive(true);
        p1name.SetActive(true);
    }
}
