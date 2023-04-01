using System;
using UnityEngine;
using System.Collections;

public class AbilityManager : MonoBehaviour
{
    //public EventHandler AbilityActivated;
    public float BiocellCharge;
    public bool IsEnergyDepleted(float drainRate)
    {  
        if (BiocellCharge <= 0)
        {
            StopAllCoroutines();
            return true;   
        }
        else
        {
            StartCoroutine(DecreaseEnergy(drainRate));
            return false;
        }
    }

    private IEnumerator DecreaseEnergy(float drainRate)
    {
        yield return new WaitForSeconds(2);
        BiocellCharge -= drainRate;
        if(BiocellCharge >= 0) //This could be the reason why energy keeps decreasing even though ability is deactive.
        {
            StartCoroutine(DecreaseEnergy(drainRate));
        }
    }
}
