using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{  
    public float BiocellCharge;
    //private Timer timer;
    //private List<float> AbilityDrainRates = new();
    //private float CombinedDrainRate;
    private void Awake()
    {
        //timer = FindObjectOfType<Timer>();
        //timer.SecondPassed += OnSecondPassed;
    }
    //public void CombineDrainRate()
    //{
    //    for (int i = 0; i < AbilityDrainRates.Count; i++)
    //    {
    //        Debug.Log(AbilityDrainRates[i]);
    //        CombinedDrainRate = AbilityDrainRates[i];
    //    }
    //    Debug.Log(CombinedDrainRate);
    //}
    public bool IsEnergyDepleted(float drainRate)
    {  
        //AbilityDrainRates.Add(drainRate);
        if (BiocellCharge <= 0)
        {
            return true;   
        }
        else
        {
            return false;
        }
    }

    [SerializeField] private float timeElapsed;
    [SerializeField] private float timePerSecond;

    public event Action<float> SecondPassed;

    //public delegate void SecondPassed(float timeElapsed);
    //public static event SecondPassed OnSecondPassed;

    private void Update()
    {
        TimePassed(Time.deltaTime);
    }

    private void TimePassed(float deltaTime)
    {
        timeElapsed += deltaTime;
        if (timeElapsed >= timePerSecond)
        {
            timeElapsed -= timePerSecond;
            //OnSecondPassed();
            //SecondPassed?.Invoke(timeElapsed);
        }
    }
    //Perhaps this should have the subscriber and the event should be inside the abilities.
    //The manager should subscribe to ability events
    protected virtual void OnSecondPassed(float energy)
    {
        SecondPassed?.Invoke(energy);
    }
    //private void OnSecondPassed(object sender, EventArgs e)
    //{
    //    DrainEnergy(CombinedDrainRate);
    //}
    private void DrainEnergy(float drainRate)
    {
        if(BiocellCharge != 0)
        {
            BiocellCharge -= drainRate;
        }       
    }
}
