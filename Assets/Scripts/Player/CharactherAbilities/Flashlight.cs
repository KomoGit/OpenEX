using UnityEngine;

public class Flashlight : MonoBehaviour,IAbility
{
    //This is a temporary measure made by me. The ability will be changed and I will make a Interface for all ability scripts to follow.
    [SerializeField] AbilityManager AbilityManager;
    [SerializeField] Light Light;
    [SerializeField] private float DrainRate;
    //[SerializeField] AudioSource m_AudioSource;
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
            //AbilityDrain();
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
