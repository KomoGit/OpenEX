using System;
using UnityEngine;

public class Agility : MonoBehaviour,IAbility
{
    [SerializeField] private AbilityManager AbilityManager;
    [SerializeField] private InternalTimer Timer;
    [SerializeField] private P_movement PlayerMovement;
    [SerializeField] private float DrainRatePerSecond;
    [SerializeField] private AudioClip AgilitySFX;
    [SerializeField] [Range(1,4)] private int AbilityLevel = 1;
    private bool AgilityEnabled = false;
    
    private float PlayerJumpForce;
    private float PlayerSpeed;

    void Awake()
    {
        PlayerMovement = FindObjectOfType<P_movement>();
        AbilityManager = FindObjectOfType<AbilityManager>();
        Timer = FindObjectOfType<InternalTimer>();

        PlayerJumpForce = PlayerMovement.CurrentJumpForce;
        PlayerSpeed = PlayerMovement.CurrentMovementSpeed;
    }
    private void Update()
    {
        if (AbilityManager.IsEnergyDepleted())
        {
            DisableAgility();
        }
    }
    public void AbilityActivate()
    {
        if (!AbilityManager.IsEnergyDepleted())
        {
            if (AgilityEnabled == false)
            {
                Debug.Log("Agility Activated");               
                EnableAgility();
            }
            else if (AgilityEnabled == true)
            {
                Debug.Log("Agility Deactivated");
                DisableAgility();
            }
        }
    }
    private void DrainPerSecond(object sender, EventArgs e)
    {
        if (!AbilityManager.IsEnergyDepleted())
        {
            AbilityManager.DrainEnergy(DrainRatePerSecond);
        }
    }

    private void EnableAgility()
    {
        AgilityEnabled = true;
        Timer.SecondPassed += DrainPerSecond;
        switch (AbilityLevel)
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
        AgilityEnabled = false;
        PlayerMovement.CurrentJumpForce = PlayerJumpForce;
        PlayerMovement.CurrentMovementSpeed = PlayerSpeed;
        Timer.SecondPassed -= DrainPerSecond;
    }
}
