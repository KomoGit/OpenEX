using UnityEngine;

public class Flashlight : MonoBehaviour,IAbility
{
    [SerializeField] AbilityManager AbilityManager;
    [SerializeField] Light Light;
    [SerializeField] private float DrainRate;
    [SerializeField] private AudioClip FlashlightSFX;
    private bool FlashlightEnabled = false;

    private void Start()
    {
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
        if (FlashlightEnabled == false && AbilityManager.BiocellCharge != 0)
        {
            FlashlightEnabled = true;
        }
        else
        {
            FlashlightEnabled = false;
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
