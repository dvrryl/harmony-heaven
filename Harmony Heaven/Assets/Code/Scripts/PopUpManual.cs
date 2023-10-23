using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManual : MonoBehaviour
{
    public Button buttonPrefab;
    public Transform popUpLocation; // Objek Transform yang akan dijadikan titik pop-up
    public KeyCode Keyboard; // Tombol yang akan digunakan untuk manual popup

    private Button currentButton; // Tombol yang sedang muncul

    // Fungsi ini akan dipanggil untuk menampilkan tombol di posisi popUpLocation
    public void ShowButton()
    {
        // Cek apakah ada tombol yang sedang ditampilkan
        if (currentButton != null)
        {
            // Jika ada, sembunyikan tombol yang sedang ditampilkan
            HideButton();
        }

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

    void Update()
    {
        if (Input.GetKeyUp(Keyboard))
        {
            // Toggle manual popup dan hide saat tombol ditekan
            if (currentButton != null)
            {
                HideButton();
            }
            else
            {
                ShowButton();
            }
        }
    }
}
