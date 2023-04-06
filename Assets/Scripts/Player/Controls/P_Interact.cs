using UnityEngine;

public class P_Interact : MonoBehaviour
{
    [SerializeField] private Camera _playerCam;
    [SerializeField] private P_movement _movement;

    private void Awake()
    {
        _movement = FindObjectOfType<P_movement>();
    }
    public void CheckInteractiveObject()
    {
        Ray ray = _playerCam.ViewportPointToRay(new Vector3(0.5f,0.5f));
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject.TryGetComponent<IInteractive>(out var interactiveObject))
            {
                Interact(interactiveObject);
            }
        }
    }
    
    private void Interact(IInteractive _intr)
    {
        if (_intr.IsActivated())
        {
            _intr.Deactivate();
            _movement.enabled = true;
        }
        else
        {
            _intr.Activate();
            _movement.enabled = false;
        }
    }
}
