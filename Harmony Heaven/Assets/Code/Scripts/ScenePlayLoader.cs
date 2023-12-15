using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayLoader : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject SettingButton;
    public GameObject ExitButton;
    public GameObject Multiplayer;
    public GameObject Training;


    // Diaktifkan secara otomatis saat tombol diinspeksi di Editor Unity
    void OnEnable()
    {
        // Mengaitkan metode masuk() dengan event onClick pada tombol
        PlayButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LoadGameplayScene);
    }

    void OnDisable()
    {
        // Membersihkan event onClick agar tidak menyimpan referensi ganda
        PlayButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(LoadGameplayScene);
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
        PlayButton.SetActive(false);
        SettingButton.SetActive(false);
        ExitButton.SetActive(false);
    }

    public void EnableGameObject()
    {
        // Aktifkan kedua game object
        Multiplayer.SetActive(true);
        Training.SetActive(true);
    }
}