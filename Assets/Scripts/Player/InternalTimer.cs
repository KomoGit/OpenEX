using System;
using System.Collections;
using UnityEngine;

public class InternalTimer : MonoBehaviour
{
    public event EventHandler SecondPassed;
    private void Awake()
    {
        StartCoroutine(StartTimer());
    }

    public IEnumerator StartTimer() //Potential performance sink, because it is enabled permanently.
    {
        const float INTERVAL = 1;
        float elapsedTime = 0f;
        while (true)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= INTERVAL)
            {
                SecondPassed?.Invoke(this, EventArgs.Empty);
                elapsedTime = 0f;
            }
        }
    }
}
