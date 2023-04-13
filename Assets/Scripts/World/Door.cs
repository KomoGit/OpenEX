using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _angle = 90f;
    [SerializeField] private bool _isLocked = false;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip OpenDoor = default;
    [SerializeField] private AudioClip CloseDoor = default;
    //public event EventHandler RemoteOpenDoor;
    private bool _isOpen = false;
    private Quaternion _startRotation;
    private Quaternion _endRotation;
    private Coroutine _coroutine;

    private void Awake()
    {  
        _startRotation = transform.rotation;
        _endRotation = _startRotation * Quaternion.Euler(0, _angle, 0);
    }   
    public void Activate()
    {
        if (!_isLocked && !IsActivated())
        {
            if(_coroutine != null)  
            {
                StopCoroutine(_coroutine);
            }        
            _coroutine = StartCoroutine(RotateDoor(_endRotation));
            PlaySound(OpenDoor);
            _isOpen = true;
        }
    }
    public void Deactivate()
    {
        if (!_isLocked && IsActivated())
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }           
            _coroutine = StartCoroutine(RotateDoor(_startRotation));
            PlaySound(CloseDoor);
            _isOpen = false;
        }
    }
    //Single function for opening or closing the door. 
    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _speed);
            yield return null;
        }
    }
    public bool IsActivated()
    {
        return _isOpen;
    }
    private void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    //protected virtual void OnRemoteOpenDoor()
    //{
    //    RemoteOpenDoor?.Invoke(this, EventArgs.Empty);
    //}
}
