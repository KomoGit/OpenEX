using System;
using UnityEngine;

public class DoorPanel : MonoBehaviour, IInteractive
{
    [SerializeField] private Door DoorObject;

    public void Activate()
    {
        DoorObject.Activate();
    }

    public void Deactivate()
    {
        DoorObject.Deactivate();
    }

    public bool IsActivated()
    {
        return DoorObject.IsOpen;
    }
}