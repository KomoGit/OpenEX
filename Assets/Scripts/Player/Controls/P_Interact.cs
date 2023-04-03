using UnityEngine;

public class P_Interact : MonoBehaviour
{
    [SerializeField] private Camera _playerCam;

    public void Interact()
    {
        Ray ray = _playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit hit, 1))
        {
            var _intr = hit.collider.gameObject.GetComponent<IInteractive>();
            _intr.Activate();     
        }
        else
        {
            return;
        }    
    }
}
