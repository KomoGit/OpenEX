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
        Light.gameObject.SetActive(false);
        AbilityManager = FindObjectOfType<AbilityManager>();
    }
    private void Update()
    {
        if (!AbilityManager.EnergyDepleted())
        {
            Light.gameObject.SetActive(FlashlightEnabled);
        }
        else
        {
            FlashlightEnabled = !AbilityManager.EnergyDepleted();
            Light.gameObject.SetActive(FlashlightEnabled);
        }
    }
    public void AbilityActivate()
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
    private void DrainPerSecond(object sender, EventArgs e)
    {
        if (!AbilityManager.EnergyDepleted())
        {
            AbilityManager.DrainEnergy(DrainRatePerSecond);
        }
    }
}
