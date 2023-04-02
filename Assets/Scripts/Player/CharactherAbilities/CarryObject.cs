using System.Collections;
using UnityEngine;

public class CarryObject : MonoBehaviour,IAbility 
{
    [Header("References")]
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _objectHolder;
    [Header("Values")]
    [SerializeField] private float abilityCooldownTimer = 1f;
    [SerializeField] private float maxGrabDistance = 10f;
    [SerializeField] private float maxWeight = 2f; //We can make this into an array, so as player upgrades the value will change.
    [SerializeField] private float lerpSpeed = 100f;
    [SerializeField] private float throwForce = 20f;

    private GameObject _objectHeld = default;
    private readonly float AlphaNonT = 1f, AlphaTransparent = 0.5f;
    private bool canUseAbility = true;

    public Rigidbody GrabbedRB { get; private set; }

    private void Update()
    {
        HoldObject();
    }
    private void FixedUpdate()
    {
        IgnorePlayerCollission();  
    }
    public void AbilityActivate()
    {
        if (GrabbedRB) DropObject();
        else CheckObject();
    }
    public void AbilityDrain()
    {
        //Not yet implemented.
    }
    private void CheckObject()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit hit, maxGrabDistance) && hit.rigidbody !=null && canUseAbility && hit.rigidbody.mass <= maxWeight)//Has too many parameters.
        {
            GrabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
            canUseAbility = false;
            if (GrabbedRB)
            {
                GrabbedRB.isKinematic = true;
            }
        }
    }
    private void HoldObject()
    {
        if (GrabbedRB) // && _grabbedRB.mass <= maxWeight
        {
            GrabbedRB.MovePosition(Vector3.Lerp(GrabbedRB.position, _objectHolder.transform.position, Time.deltaTime * lerpSpeed));
        }
        else if (GrabbedRB && GrabbedRB.mass >= maxWeight)
        {
            GrabbedRB.isKinematic = false;
            GrabbedRB = null;
        }
    }
    private void DropObject()
    {
        GrabbedRB.isKinematic = false;
        GrabbedRB = null;
        StartCoroutine(ResetAbility());
    }
    public void ThrowObject()
    {
        if (GrabbedRB)
        {
            GrabbedRB.isKinematic = false;
            GrabbedRB.AddForce(_camera.transform.forward * throwForce / GrabbedRB.mass, ForceMode.VelocityChange);
            GrabbedRB = null;
            StartCoroutine(ResetAbility());
        }
    }
    private void IgnorePlayerCollission()
    {
        if (GrabbedRB)
        {
            _objectHeld = GrabbedRB.gameObject;
            GrabbedRB.GetComponent<Collider>().enabled = false;    
            ChangeAlpha(GrabbedRB.gameObject.GetComponent<Renderer>().material, AlphaTransparent);
        }
        else 
        {
            if (_objectHeld != null) 
            {
                _objectHeld.GetComponent<Collider>().enabled = true;
                ChangeAlpha(_objectHeld.GetComponent<Renderer>().material, AlphaNonT);
            }         
        }
    }
    //Rendering mode of objects must be set to Transparent for this script to work. Otherwise the changes will not be visible.
    private void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new (oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
    private IEnumerator ResetAbility()
    {
        yield return new WaitForSeconds(abilityCooldownTimer);
        canUseAbility = true;
    }
}
