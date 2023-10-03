using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddGoodMove()
    {
        score += 20;
        scoreText.text = score.ToString();
    }

    public void AddPerfectMove()
    {
        score += 50;
        scoreText.text = score.ToString();
    }

    public void AddMissedMove()
    {
        score -= 25;
        scoreText.text = score.ToString();
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
