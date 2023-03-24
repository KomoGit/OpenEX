using UnityEngine;

public class CarryObject : MonoBehaviour,IAbility 
{
    [Header("References")]
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _objectHolder;
    [Header("Values")]
    [SerializeField] private float maxGrabDistance = 10f;
    [SerializeField] private float maxWeight = 2f; //We can make this into an array, so as player upgrades the value will change.
    [SerializeField] private float lerpSpeed = 100f;
    [SerializeField] private float throwForce = 20f;

    private GameObject _objectHeld = default;
    private Rigidbody _grabbedRB;
    private float AlphaNonT = 1f, AlphaTransparent = 0.5f;

    private void Update()
    {
        IgnorePlayerCollission();
    }
    private void FixedUpdate()
    {   
        HoldObject();      
        ClampItemHolder();
    }
    public void AbilityActivate()
    {
        if (_grabbedRB)
        {
            DropObject();
        }
        else
        {
            CheckObject();
        }
    }
    public void AbilityDrain()
    {
        
    }

    private void DropObject()
    {
        _grabbedRB.isKinematic = false;
        _grabbedRB = null;
    }
    private void CheckObject()
    {
        RaycastHit hit;
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out hit, maxGrabDistance) && hit.rigidbody.mass <= maxWeight)
        {
            _grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (_grabbedRB)
            {
                _grabbedRB.isKinematic = true;
            }
        }
    }
    private void HoldObject()
    {
        if (_grabbedRB) // && _grabbedRB.mass <= maxWeight
        {
            _grabbedRB.MovePosition(Vector3.Lerp(_grabbedRB.position, _objectHolder.transform.position, Time.deltaTime * lerpSpeed));
        }
        else if (_grabbedRB && _grabbedRB.mass >= maxWeight)
        {
            _grabbedRB.isKinematic = false;
            _grabbedRB = null;
        }
    }
    private void IgnorePlayerCollission()
    {
        if (_grabbedRB)
        {
            _objectHeld = _grabbedRB.gameObject;
            //Physics.IgnoreCollision(_grabbedRB.GetComponent<Collider>(), _playerCollider.GetComponent<Collider>());
            _grabbedRB.GetComponent<Collider>().enabled = false;    
            ChangeAlpha(_grabbedRB.gameObject.GetComponent<Renderer>().material, AlphaTransparent);
        }
        else 
        {
            if (_objectHeld != null) 
            {
                _objectHeld.GetComponent<Collider>().enabled = true;
                //Physics.IgnoreCollision(_objectHeld.GetComponent<Collider>(), _playerCollider.GetComponent<Collider>(), false);
                ChangeAlpha(_objectHeld.GetComponent<Renderer>().material, AlphaNonT);
            }         
        }
    }
    //Rendering mode of objects must be set to Transparent for this script to work. Otherwise the changes will not be visible.
    private void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
    private void ClampItemHolder() 
    {
        //_objectHolder.localPosition = 
    }
    public void ThrowObject()
    {
        if (_grabbedRB)
        {
            _grabbedRB.isKinematic = false;
            _grabbedRB.AddForce(_camera.transform.forward * throwForce / _grabbedRB.mass, ForceMode.VelocityChange);
            _grabbedRB = null;
        }       
    }
}
