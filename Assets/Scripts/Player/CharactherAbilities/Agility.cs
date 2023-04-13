using System;
using UnityEngine;

public class Agility : MonoBehaviour,IAbility
{
    [SerializeField] private AbilityManager AbilityManager;
    //[SerializeField] private P_movement PlayerMovement;
    [SerializeField] private float DrainRatePerSecond;
    [SerializeField] private AudioClip AgilitySFX;
    [SerializeField] [Range(1,4)] private int abilityLevel = 1;
    private bool AgilityEnabled = false;

    void Start()
    {
        //PlayerMovement = FindObjectOfType<P_movement>();
        AbilityManager = FindObjectOfType<AbilityManager>();    
    }

    public void AbilityActivate()
    {
        if (AbilityManager.IsEnergyDepleted())
        {
            return;
        }
        else
        {
            if (AgilityEnabled == false)
            {
                Debug.Log("Agility Activated");
                AbilityManager.SecondPassed += DrainPerSecond;
                AgilityEnabled = true;
            }
            else
            {
                Debug.Log("Agility Deactivated");
                AbilityManager.SecondPassed -= DrainPerSecond;
                AgilityEnabled = false;
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
            AgilityEnabled = false;
        }
    }
}
