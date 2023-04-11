using UnityEngine;

public class CameraPanel : MonoBehaviour,IInteractive
{
    [SerializeField] private Camera _camera;
    private InputManager _movement;
    private void Awake()
    {
        _movement = FindObjectOfType<InputManager>();
        _camera.gameObject.SetActive(false);       
    }
    public void Activate()
    {
        _camera.gameObject.SetActive(true);
    }
    public void Deactivate() 
    { 
        _camera.gameObject.SetActive(false);    
    }
    public bool IsActivated()
    {
        if(_camera.gameObject.activeInHierarchy) 
        {
            _movement.AllowPlayerMovement = false;
            return true;
        }
        else
        {
            _movement.AllowPlayerMovement = true;
            return false;           
        }
    }
}
