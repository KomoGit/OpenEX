using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float Duration = 10f;
    private float timeRemaining;
    private float timeSinceLastEvent;
    public bool isRunning = false;
    public event EventHandler SecondPassed;
    public event EventHandler TimerFinished;

    private void Start()
    {
        timeRemaining = Duration;
        timeSinceLastEvent = 0f;
    }

    private void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;
            timeSinceLastEvent += Time.deltaTime;

            if (timeSinceLastEvent >= 1f)
            {
                // Fire the SecondPassed event
                OnSecondPassed();

                // Reset the timeSinceLastEvent counter
                timeSinceLastEvent = 0f;
            }

            if (timeRemaining <= 0f)
            {
                // Timer has finished
                isRunning = false;
                OnTimerFinished();
                timeRemaining = 0f;
            }
        }
    }
    public void StartTimer()
    {
        isRunning = true;
    }
    public void StopTimer()
    {
        isRunning = false;
    }
    public void ResetTimer()
    {
        isRunning = false;
        timeRemaining = Duration;
        timeSinceLastEvent = 0f;
    }
    protected virtual void OnSecondPassed()
    {
        SecondPassed?.Invoke(this, EventArgs.Empty);
    }
    protected virtual void OnTimerFinished()
    {
        TimerFinished?.Invoke(this, EventArgs.Empty);
    }
}
