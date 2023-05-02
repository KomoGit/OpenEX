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
    public bool IsEnergyDepleted()
    {
        return CurrentBiocellCharge == 0;
    }
    //According to Chat-GPT this is more performant.
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