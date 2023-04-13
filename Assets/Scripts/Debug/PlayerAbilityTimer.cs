using System;
using UnityEngine;

public class PlayerAbilityTimer : MonoBehaviour
{
    AbilityManager abilityManager;
    private void Awake()
    {
        abilityManager = FindObjectOfType<AbilityManager>();
        //abilityManager.SecondPassed += HandleSecondPassed;
    }

    private void HandleSecondPassed(object sender,EventArgs e)
    {
        Debug.Log("One second has passed.");
    }
}
