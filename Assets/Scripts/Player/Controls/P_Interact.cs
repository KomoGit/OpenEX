using UnityEngine;

public class P_Interact : MonoBehaviour
{
    [SerializeField] private Camera _playerCam;
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
        }
        else
        {
            _intr.Activate();
        }
    }
}
