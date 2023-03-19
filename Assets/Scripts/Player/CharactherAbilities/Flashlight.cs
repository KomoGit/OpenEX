using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //This is a temporary measure made by me. The ability will be changed and I will make a Interface for all ability scripts to follow.
    [SerializeField] Light Light;
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
    }

    public void EnableDisableLight()
    {
        if (FlashlightEnabled == false)
        {
            FlashlightEnabled = true;
        }
        else
        {
            FlashlightEnabled = false;
        }
    }

    /*private void PlayFlashSound()
    {
        m_AudioSource.clip = FlashlightSound;
        m_AudioSource.Play();
    }*/
}
