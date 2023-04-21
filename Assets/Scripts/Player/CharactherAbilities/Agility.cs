using System;
using UnityEngine;

public class Agility : MonoBehaviour,IAbility
{
    [SerializeField] private AbilityManager AbilityManager;
    [SerializeField] private P_movement PlayerMovement;
    [SerializeField] private float DrainRatePerSecond;
    [SerializeField] private AudioClip AgilitySFX;
    [SerializeField] [Range(1,4)] private int abilityLevel = 1;
    private bool AgilityEnabled = false;
    
    private float PlayerJumpForce;
    private float PlayerSpeed;

    void Awake()
    {
        PlayerJumpForce = PlayerMovement.CurrentJumpForce;
        PlayerSpeed = PlayerMovement.CurrentMovementSpeed;
    }

    void Start()
    {
        PlayerMovement = FindObjectOfType<P_movement>();
        AbilityManager = FindObjectOfType<AbilityManager>();    
    }
    public void AbilityActivate()
    {
        if (AbilityManager.EnergyDepleted())
        {
            return;
        }
        else
        {
            if (AgilityEnabled == false)
            {
                Debug.Log("Agility Activated");
                AbilityManager.SecondPassed += DrainPerSecond;
                EnableAgility();
            }
            else if (AgilityEnabled == true || AbilityManager.EnergyDepleted())
            {
                Debug.Log("Agility Deactivated");
                AbilityManager.SecondPassed -= DrainPerSecond;
                DisableAgility();   
            }
        }
    }
    private void DrainPerSecond(object sender, EventArgs e)
    {
        if (!AbilityManager.EnergyDepleted())
        {
            AbilityManager.DrainEnergy(DrainRatePerSecond);
        }
        else
        {
            AgilityEnabled = false;
        }
    }

    private void EnableAgility()
    {
        AgilityEnabled = true;
        switch (abilityLevel)
        {
            case 2:
                PlayerMovement.CurrentMovementSpeed *= 2;
                PlayerMovement.CurrentJumpForce *= 2;
                //Add fall damage reducer as well. For all cases
                break;
            case 3:
                PlayerMovement.CurrentMovementSpeed *= 3;
                PlayerMovement.CurrentJumpForce *= 3;
                break;
            case 4:
                PlayerMovement.CurrentMovementSpeed *= 4;
                PlayerMovement.CurrentJumpForce *= 4;
                break;
            default:
                PlayerMovement.CurrentMovementSpeed *= 2f;
                PlayerMovement.CurrentJumpForce *= 2f;
                break;
        }
    }
    private void DisableAgility()
    {
        PlayerMovement.CurrentJumpForce = PlayerJumpForce;
        PlayerMovement.CurrentMovementSpeed = PlayerSpeed;
        AgilityEnabled = false;
    }
}
