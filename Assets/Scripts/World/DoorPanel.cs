using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanel : MonoBehaviour, IInteractive
{
    [SerializeField] private Door DoorObject;

    private void Awake()
    {

    }

    public void Activate()
    {
        
    }

    public void Deactivate()
    {

    }

    public bool IsActivated()
    {
        throw new NotImplementedException();
    }



}
