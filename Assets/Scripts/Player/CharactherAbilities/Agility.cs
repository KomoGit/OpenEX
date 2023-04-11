using UnityEngine;

public class Agility : MonoBehaviour,IAbility
{
    [SerializeField] private AbilityManager AbilityManager;
    [SerializeField] private P_movement PlayerMovement;
    [SerializeField] private Timer timerObject;
    [SerializeField] private float DrainRate;
    [SerializeField] private AudioClip AgilitySFX;
    [SerializeField] [Range(1,4)] private int abilityLevel = 1;
    private bool AgilityEnabled = false;

    void Start()
    {
        PlayerMovement = FindObjectOfType<P_movement>();
        timerObject = FindObjectOfType<Timer>();  
    }

    void Update()
    {
        if (AgilityEnabled)
        {
            AbilityDrain();
        }
    }

    public void AbilityActivate()
    {
        if (AbilityManager.BiocellCharge == 0)
        {
            return;
        }
        else
        {
            if (AgilityEnabled == false)
            {
                Debug.Log("Agility Activated");
                timerObject.isRunning = true;
                AgilityEnabled = true;
            }
            else
            {
                //This will most likely cause bugs as other abilities also reset timer. (Spoiler Alert: It Does)
                Debug.Log("Agility Deactivated");
                timerObject.isRunning = false;
                timerObject.ResetTimer();
                AgilityEnabled = false;
            }
        }
    }

    public void AbilityDrain()
    {
        if (AbilityManager.IsEnergyDepleted(DrainRate))
        {
            AgilityEnabled = false;
        }
        else
        {
            AbilityManager.IsEnergyDepleted(DrainRate);
        }
    }
}
