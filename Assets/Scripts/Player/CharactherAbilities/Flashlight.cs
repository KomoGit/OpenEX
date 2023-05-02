using System;
using UnityEngine;

public class Flashlight : MonoBehaviour,IAbility
{
    [SerializeField] private AbilityManager AbilityManager;
    [SerializeField] private Light Light;
    [SerializeField] private float DrainRatePerSecond;
    [SerializeField] private AudioClip FlashlightSFX;
    [SerializeField] private bool FlashlightEnabled = false;

    private void Awake()
    {
        AbilityManager = FindObjectOfType<AbilityManager>();
    }
    private void Update()
    {
        Light.gameObject.SetActive(FlashlightEnabled);
        if (AbilityManager.EnergyDepleted())
        {
            FlashlightEnabled = false;  
        }
    }
    public void AbilityActivate() //DO NOT RENAME, PART OF INTERFACE
    {
        if (!AbilityManager.EnergyDepleted()) 
        {
            if (FlashlightEnabled == false)
            {
                Debug.Log("Flashlight Activated");
                FlashlightEnabled = true;
                AbilityManager.SecondPassed += DrainPerSecond;
            }
            else if (FlashlightEnabled == true)
            {
                Debug.Log("Flashlight Deactivated");
                AbilityManager.SecondPassed -= DrainPerSecond;
                FlashlightEnabled = false;
            }
        }
    }
    private void DrainPerSecond(object sender, EventArgs e) //ALSO PART OF INTERFACE
    {
        if (!AbilityManager.EnergyDepleted())
        {
            AbilityManager.DrainEnergy(DrainRatePerSecond);
        }
    }
}
