using System;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{      
    [SerializeField] private float BiocellCharge = 100;
    public float CurrentBiocellCharge; //Turn it to private once the development cycle is over.
    public event EventHandler SecondPassed;
    private readonly float TimePerSecond = 1;
    private float timeElapsed;


    private void Awake()
    {
        CurrentBiocellCharge = BiocellCharge;      
    }
    public bool IsEnergyDepleted()
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
    private void Update()
    {
        TimePassed();
    }
    private void TimePassed()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= TimePerSecond)
        {
            timeElapsed -= TimePerSecond;
            SecondPassed?.Invoke(this,EventArgs.Empty);
        }
    }
    public void DrainEnergy(float drainRate)
    {
        CurrentBiocellCharge -= drainRate;
    }
}