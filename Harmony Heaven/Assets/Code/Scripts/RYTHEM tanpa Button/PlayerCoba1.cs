using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayLoader : MonoBehaviour
{
   public void LoadGameplayScene()
    {
        // Memuat scene gameplay dengan nama "Gameplay" (gantilah dengan nama yang sesuai)
        SceneManager.LoadScene("Gameplay");
        Debug.Log("Gameplay");
    }

}