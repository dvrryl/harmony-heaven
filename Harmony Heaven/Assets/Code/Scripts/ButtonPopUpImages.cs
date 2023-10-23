using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPopUpImages : MonoBehaviour
{
    public Transform popUpLocation; // Objek Transform yang akan dijadikan titik pop-up
    public float interval; // Interval waktu (dalam detik)
    public Button[] buttonPrefabs; // Daftar prefab tombol

    private List<Button> currentButtons = new List<Button>(); // Tombol yang sedang muncul

    void Start()
    {
        StartCoroutine(ShowAndHideButtonsPeriodically());
    }

    private IEnumerator ShowAndHideButtonsPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            ShowAllButtons();
            yield return new WaitForSeconds(interval);
            HideAllButtons();
            yield return new WaitForSeconds(interval);
        }
    }

    private void ShowAllButtons()
    {
        foreach (Button buttonPrefab in buttonPrefabs)
        {
            ShowButton(buttonPrefab);
        }
    }

    private void ShowButton(Button buttonPrefab)
    {
        Button currentButton = Instantiate(buttonPrefab, popUpLocation);

        currentButton.transform.position = popUpLocation.position;

        currentButtons.Add(currentButton);

        Debug.Log("Showing button: " + currentButton.name); // Debugging statement
    }

    private void HideAllButtons()
    {
        int buttonCount = currentButtons.Count;
        for (int i = 0; i < buttonCount; i++)
        {
            Button button = currentButtons[i];
            Debug.Log("Destroying button: " + button.name); // Debugging statement
            Destroy(button.gameObject);
        }
        currentButtons.Clear();
    }
}
