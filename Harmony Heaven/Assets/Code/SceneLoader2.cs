using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
        Debug.Log("Gameplay");
    }
}
