using UnityEngine;

public class Flashlight : MonoBehaviour,IAbility
{
    [SerializeField] private AbilityManager AbilityManager;
    [SerializeField] private Timer timer;
    [SerializeField] private Light Light;
    [SerializeField] private float DrainRate;
    [SerializeField] private AudioClip FlashlightSFX;
    private bool FlashlightEnabled = false;
    // Perhaps the best approach would
    // be to move the system from booleans to event system.
    private void Start()
    {
        timer = FindObjectOfType<Timer>();  
        Light.gameObject.SetActive(false);
    }
    private void Update()
    {
        Light.gameObject.SetActive(FlashlightEnabled);
        if(FlashlightEnabled)
        {
            AbilityDrain();
        }
    }
    public void AbilityActivate()
    {
        if(AbilityManager.BiocellCharge == 0)
        {
            return;
        }
        else
        {
            if (FlashlightEnabled == false)
            {
                timer.isRunning = true;
                FlashlightEnabled = true;
            }
            else
            {
                timer.isRunning = false;
                timer.ResetTimer();
                FlashlightEnabled = false;
            }
        }     
    }
    public void AbilityDrain()
    {
      if (AbilityManager.IsEnergyDepleted(DrainRate))
      {
        FlashlightEnabled = false;
      }
      else
      {
        AbilityManager.IsEnergyDepleted(DrainRate);
      } 
    }
}
