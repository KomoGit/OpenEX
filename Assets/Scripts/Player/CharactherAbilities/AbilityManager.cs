using System;
using System.Collections;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{      
    [SerializeField] private float BiocellCharge = 100;
    public float CurrentBiocellCharge;
    public event EventHandler SecondPassed;

    private void Awake()
    {
        CurrentBiocellCharge = BiocellCharge;
        StartCoroutine(StartTimer());
    }
    public bool EnergyDepleted()
    {
        return CurrentBiocellCharge == 0;
    }
    //According to Chat-GPT this is more performant.
    public IEnumerator StartTimer()
    {
        float Interval = 1;
        float elapsedTime = 0f;
        while (!EnergyDepleted())
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= Interval)
            {
                SecondPassed?.Invoke(this,EventArgs.Empty);
                elapsedTime = 0f;
            }
        }
    }
    public void DrainEnergy(float drainRate)
    {
        CurrentBiocellCharge -= drainRate;
    }
}