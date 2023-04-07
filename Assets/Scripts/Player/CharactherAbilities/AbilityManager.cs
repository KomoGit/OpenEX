using System;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private Timer timer;
    public float BiocellCharge;
    private float drainRate;
    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        timer.SecondPassed += OnSecondPassed;
    }

    public bool IsEnergyDepleted(float drainRate)
    {  
        this.drainRate = drainRate;
        if (BiocellCharge <= 0)
        {
            return true;   
        }
        else
        {
            return false;
        }
    }
    private void OnSecondPassed(object sender, EventArgs e)
    {
        DrainEnergy(drainRate);
    }
    private void DrainEnergy(float drainRate)
    {
        if(BiocellCharge != 0)
        {
            BiocellCharge -= drainRate;
        }       
    }
}
