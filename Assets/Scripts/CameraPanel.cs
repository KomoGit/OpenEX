using UnityEngine;

public class CameraPanel : MonoBehaviour,IInteractive
{
    [SerializeField] private Camera _camera;
    private void Awake()
    {
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
            return true;
        }
        else
        {
            return false;
        }
    }
}
