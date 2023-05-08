using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSilent : MonoBehaviour
{
    [SerializeField] private AbilityManager abilityManager;
    [SerializeField] private float DrainRatePerSecond;
    [SerializeField][Range(1, 4)] private int abilityLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
