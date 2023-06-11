using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    // TODO: Implement lock strenght and lockpicking mechanics to the game.
    // For electronic doors, we will use Multitool, for regular ones, we will use lockpick.
    // Some doors in game can use both lockpick and multitool.
    [SerializeField] private float OpenCloseSpeed = 2f;
    [SerializeField] private float Angle = 90f;
    [SerializeField] private bool IsLocked = false;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip OpenDoor = default;
    [SerializeField] private AudioClip CloseDoor = default;
    //public event EventHandler RemoteOpenDoor;
    private bool IsOpen = false;
    private Quaternion StartRotation;
    private Quaternion EndRotation;
    private Coroutine _Coroutine;

    private void Awake()
    {  
        StartRotation = transform.rotation;
        EndRotation = StartRotation * Quaternion.Euler(0, Angle, 0);
    }   
    public void Activate()
    {
        if (!IsLocked && !IsActivated())
        {
            if(_Coroutine != null)  
            {
                StopCoroutine(_Coroutine);
            }        
            _Coroutine = StartCoroutine(RotateDoor(EndRotation));
            PlaySound(OpenDoor);
            IsOpen = true;
        }
    }
    public void Deactivate()
    {
        if (!IsLocked && IsActivated())
        {
            if (_Coroutine != null)
            {
                StopCoroutine(_Coroutine);
            }           
            _Coroutine = StartCoroutine(RotateDoor(StartRotation));
            PlaySound(CloseDoor);
            IsOpen = false;
        }
    }
    //Single function for opening or closing the door. 
    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * OpenCloseSpeed);
            yield return null;
        }
    }
    public bool IsActivated()
    {
        return IsOpen;
    }
    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
    //protected virtual void OnRemoteOpenDoor()
    //{
    //    RemoteOpenDoor?.Invoke(this, EventArgs.Empty);
    //}
}
