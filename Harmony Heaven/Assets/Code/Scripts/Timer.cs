using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // The time remaining in the round in seconds.
    //public Text timerText; // The text object that will display the timer.

    void Start()
    {
        // Start the timer.
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0f)
        {
            // Update the timer text.
         //   timerText.text = timeRemaining.ToString("F2");

            // Subtract the delta time from the remaining time.
            timeRemaining -= Time.deltaTime;

            // Wait for the next frame.
            yield return null;
        }

        // The timer has expired.
        // Do something when the timer expires, such as ending the round.
    }
}
