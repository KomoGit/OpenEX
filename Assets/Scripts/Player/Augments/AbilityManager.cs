using UnityEngine;

[RequireComponent(typeof(InternalTimer))]
public class AbilityManager : MonoBehaviour
{      
    [SerializeField] private float BiocellCharge = 100;
    public float CurrentBiocellCharge;

    private void Awake()
    {
        CurrentBiocellCharge = BiocellCharge;
    }
    public bool IsEnergyDepleted()
    {
        return CurrentBiocellCharge == 0;
    }
    public void DrainEnergy(float drainRate)
    {
        CurrentBiocellCharge -= drainRate;
    }
}