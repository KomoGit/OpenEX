using System;
using System.Collections;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{      
    [SerializeField] private float BiocellCharge = 100;
    public float CurrentBiocellCharge; //Turn it to private once the development cycle is over.
    public event EventHandler SecondPassed;
    private readonly float Interval = 1;

    private void Awake()
    {
        CurrentBiocellCharge = BiocellCharge;      
    }
    private void Start()
    {
        StartCoroutine(StartTimer());
    }
    public bool EnergyDepleted()
    {  
        if (CurrentBiocellCharge <= 0)
        {
            return true;   
        }
        else
        {
            return false;
        }
    }
    //According to Chat-GPT this is more performant.
    private IEnumerator StartTimer()
    {
        float elapsedTime = 0f;
        while (!EnergyDepleted())//Perhaps this is why the bug happens, the ability keeps draining after the charge is out.
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