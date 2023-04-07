using System;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private Timer timer;
    public float BiocellCharge;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        timer.SecondPassed += OnSecondPassed;
    }

    public bool IsEnergyDepleted(float drainRate)
    {  
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
        DrainEnergy(1f);
    }
    private void DrainEnergy(float drainRate)
    {
        if(BiocellCharge != 0)
        {
            BiocellCharge -= drainRate;
        }       
    }
}
