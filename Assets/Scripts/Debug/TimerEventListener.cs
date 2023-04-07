using System;
using UnityEngine;

public class TimerEventListener : MonoBehaviour
{
    private void Start()
    {
        // Get the Timer component on the same game object
        Timer timer = GetComponent<Timer>();

        // Add a listener to the SecondPassed event
        timer.SecondPassed += OnSecondPassed;
        timer.TimerFinished += OnTimerFinished;
    }

    private void OnSecondPassed(object sender, EventArgs e)
    {
        // Do something every second (e.g. update a UI element)
        Debug.Log("One second has passed!");
    }

    private void OnTimerFinished(object sender, EventArgs e)
    {
        Debug.Log("Timer has finished!");
    }
}
