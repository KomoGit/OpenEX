using UnityEngine;

public class ResetBiocharge : MonoBehaviour
{
    AbilityManager abilityManager;

    private void Awake()
    {
        abilityManager = FindObjectOfType<AbilityManager>();    
    }
    public void SetEnergyFull() 
    {
        abilityManager.BiocellCharge = 100f;
    }
}
