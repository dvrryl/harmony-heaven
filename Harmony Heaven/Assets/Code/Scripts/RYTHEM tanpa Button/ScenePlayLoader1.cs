using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayLoader1 : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("SelectCharacter");
        Debug.Log("uhuy");
    }
}
