using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class P1Choose : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject BGP2;
    public GameObject BGP1;
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
        StartButton.SetActive(false);
        BGP1.SetActive(false);

    }

    public void EnableGameObject()
    {
        // Aktifkan kedua game object
        BGP2.SetActive(true);
    }
}
