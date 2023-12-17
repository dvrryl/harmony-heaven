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
        selectedChar = selectedChar - 1;
        if (selectedChar < 0)
        {
            selectedChar = characters.Count -1;

        }
        sr.sprite = characters[selectedChar];
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerCharacter, "Assets/SelectChar.prefabs");
        SceneManager.LoadScene("Gameplay");
    }
}
