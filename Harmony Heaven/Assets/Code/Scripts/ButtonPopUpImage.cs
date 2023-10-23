using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPopUpImage : MonoBehaviour
{
    public Button buttonPrefab;
    public Transform popUpLocation; // Objek Transform yang akan dijadikan titik pop-up
    public float interval; // Interval waktu (dalam detik)
    
    private Button currentButton; // Tombol yang sedang muncul

    void Start()
    {
        // Memulai proses popup otomatis
        InvokeRepeating("TogglePopup", interval, interval);
    }

    // Fungsi ini akan dipanggil untuk menampilkan atau menyembunyikan tombol secara otomatis
    private void TogglePopup()
    {
        if (currentButton != null)
        {
            // Jika ada tombol yang ditampilkan, sembunyikan
            HideButton();
        }
        else
        {
            // Jika tidak ada tombol yang ditampilkan, tampilkan
            ShowButton();
        }
    }

    // Fungsi ini akan dipanggil untuk menampilkan tombol di posisi popUpLocation
    public void ShowButton()
    {
        // Buat salinan tombol dari prefab
        currentButton = Instantiate(buttonPrefab, popUpLocation);

        // Atur posisi tombol sesuai dengan posisi popUpLocation
        currentButton.transform.position = popUpLocation.position;
    }

    // Fungsi ini akan dipanggil untuk menyembunyikan tombol
    public void HideButton()
    {
        if (currentButton != null)
        {
            Destroy(currentButton.gameObject);
            currentButton = null;
        }
    }
}