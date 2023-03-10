using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] Light Light;
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] private AudioClip FlashlightSound;
    //Always Assign an input manager and inherit button codes from this script. IManager should always be present in levels, it is made into a prefab at the moment.
    private bool toggleOn = false;
    [NonSerialized]public KeyCode flashLightKey = default;
    //InputManager inputManager;

    private void Start()
    {
        //Keys();
        Light.gameObject.SetActive(false);
        m_AudioSource.GetComponent<AudioSource>();
        //inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(flashLightKey))
        {
            if (toggleOn == false)
            {
                Light.gameObject.SetActive(true);
                toggleOn = true;
                PlayFlashSound();
            }
            else
            {
                Light.gameObject.SetActive(false);
                toggleOn = false;
                PlayFlashSound();
            }
        }
    }
    /*private void Keys()
    {
        flashLightKey = inputManager.flashLightKey;
    }*/
    private void PlayFlashSound()
    {
        m_AudioSource.clip = FlashlightSound;
        m_AudioSource.Play();
    }
}
