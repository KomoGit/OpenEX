using System;
using UnityEngine;

public class Flashlight : MonoBehaviour,IAbility
{
    [SerializeField] private AbilityManager AbilityManager;
    [SerializeField] private Light Light;
    [SerializeField] private float DrainRatePerSecond;
    [SerializeField] private AudioClip FlashlightSFX;
    private bool FlashlightEnabled = false;

    private void Awake()
    {
        Light.gameObject.SetActive(false);
        AbilityManager = FindObjectOfType<AbilityManager>();
    }
    private void Update()
    {
        Light.gameObject.SetActive(FlashlightEnabled);
    }
    public void AbilityActivate()
    {
        if(AbilityManager.IsEnergyDepleted())
        {
            return;
        }
        else
        {
            if (FlashlightEnabled == false)
            {
                Debug.Log("Flashlight Activated");
                AbilityManager.SecondPassed += DrainPerSecond;
                FlashlightEnabled = true;
            }
            else
            {
                Debug.Log("Flashlight Deactivated");
                AbilityManager.SecondPassed -= DrainPerSecond;
                FlashlightEnabled = false;
            }
        }     
    }
    private void DrainPerSecond(object sender, EventArgs e)
    {
        if (!AbilityManager.IsEnergyDepleted())
        {
            AbilityManager.DrainEnergy(DrainRatePerSecond);
        }
        else
        {
            FlashlightEnabled = false;
        }    
    }
}
