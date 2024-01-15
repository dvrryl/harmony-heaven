using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> characters = new List<Sprite>();
    private int selectedChar = 0;
    public GameObject playerCharacter;

    void Start()
    {
        sr.sprite = characters[selectedChar];
    }

    public void NextOption()
    {
        selectedChar = selectedChar + 1;
        if (selectedChar == characters.Count)
        {
            selectedChar = 0;

        }
        sr.sprite = characters[selectedChar];
    }

    public void BackOption()
    {
        Debug.Log("Selected Character Index: " + selectedChar);
        selectedChar = selectedChar - 1;
        if (selectedChar > 0)
        {
            Debug.Log("Selected Character Indexdi if: " + selectedChar);
            selectedChar = characters.Count -1;

        }
        Debug.Log("Selected Character Index setelah if: " + selectedChar);
        sr.sprite = characters[selectedChar];
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerCharacter, "Assets/SelectChar.prefabs");
        SceneManager.LoadScene("Gameplay");
    }
}
