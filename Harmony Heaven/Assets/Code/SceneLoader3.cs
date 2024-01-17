using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader3 : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main Menu");
    }
}
