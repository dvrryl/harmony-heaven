using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentScore;

    public void AddGoodMove()
    {
        currentScore += 20;
    }

    public void AddPerfectMove()
    {
        currentScore += 50;
    }

    public void AddMissedMove()
    {
        currentScore -= 10;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

}
