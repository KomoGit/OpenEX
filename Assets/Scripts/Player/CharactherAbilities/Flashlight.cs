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
        AbilityManager = FindObjectOfType<AbilityManager>();
    }
    private void Update()
    {
        Light.gameObject.SetActive(FlashlightEnabled);
        if (AbilityManager.IsEnergyDepleted())
        {
            DisableFlashlight();
        }
    }
    public void AbilityActivate() //DO NOT RENAME, PART OF INTERFACE
    {
        if (!AbilityManager.IsEnergyDepleted()) 
        {
            if (FlashlightEnabled == false)
            {
                Debug.Log("Flashlight Activated");
                EnableFlashlight();
            }
            else if (FlashlightEnabled == true)
            {
                Debug.Log("Flashlight Deactivated");
                DisableFlashlight();
            }
        }
    }
    private void DrainPerSecond(object sender, EventArgs e) //ALSO PART OF INTERFACE
    {
        if (!AbilityManager.IsEnergyDepleted())
        {
            AbilityManager.DrainEnergy(DrainRatePerSecond);
        }
    }
    private void EnableFlashlight()
    {
        FlashlightEnabled = true;
        AbilityManager.SecondPassed += DrainPerSecond;
    }
    private void DisableFlashlight()
    {
        AbilityManager.SecondPassed -= DrainPerSecond;
        FlashlightEnabled = false;
    }

}
