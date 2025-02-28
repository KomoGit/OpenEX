using System;
using System.Collections;
using UnityEngine;

public class CarryObject : MonoBehaviour, IAbility
{
    [Header("References")]
    [SerializeField] private AbilityManager AbilityManager;
    [SerializeField] private InternalTimer Timer;
    [SerializeField] private Collider PlayerCollider;
    [SerializeField] private Camera Camera;
    [SerializeField] private Transform ObjectHolder;
    [Header("Values")]
    [SerializeField] private float DrainRatePerSecond = 1f;
    [SerializeField] private float AbilityCooldownTimer = 1f;
    [SerializeField] private float MaxGrabDistance = 10f;
    [SerializeField] private float MaxWeight = 5f;
    [SerializeField] private float LerpSpeed = 100f;
    [SerializeField] private float[] ThrowForces = new float[4] { 20f,25f,30f,35f};
    [SerializeField][Range(1, 4)] private int AbilityLevel = 1;

    private GameObject ObjectHeld = default;
    private readonly float AlphaNonT = 1f, AlphaTransparent = 0.5f;
    private float ThrowForce;
    private bool GrabItemCooldown = true; //Used to prevent spam of throw ability.
    public Rigidbody GrabbedRB { get; private set; }
    private void Awake()
    {
        AbilityManager = FindObjectOfType<AbilityManager>();
        Timer = FindAnyObjectByType<InternalTimer>();   
    }
    private void FixedUpdate()
    {
        if (GrabbedRB == null) Timer.SecondPassed -= DrainEnergyPerSecond;
        HoldObject();        
        IgnoreCollision();
    }
    #region IAbility Components
    public void AbilityActivate()
    {
        if (GrabbedRB)
        {
            DropObject();
        }
        else
        {
            CheckObject();
        }
    }
    private void DrainEnergyPerSecond(object sender, EventArgs e)
    {
        if (!AbilityManager.IsEnergyDepleted())
        {
            AbilityManager.DrainEnergy(DrainRatePerSecond);
        }
    }
    #endregion

    #region Primary Components   
    private void CheckAbilityLevel(Rigidbody GrabbedRB)
    {
        switch (GrabbedRB.mass)
        {
            case 2:
                DrainRatePerSecond = 0.5f;
                ThrowForce = ThrowForces[1];
                Timer.SecondPassed += DrainEnergyPerSecond;
                break;
            case 3:
                DrainRatePerSecond = 1.0f;
                ThrowForce = ThrowForces[2];
                Timer.SecondPassed += DrainEnergyPerSecond;
                break;
            case 4:
                DrainRatePerSecond = 1.5f;
                ThrowForce = ThrowForces[3];
                Timer.SecondPassed += DrainEnergyPerSecond;
                break;
            default:
                ThrowForce = ThrowForces[0];
                break;
        }
    }
    private void CheckObject()
    {
        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));                                         
        if (Physics.Raycast(ray, out RaycastHit hit, MaxGrabDistance) && hit.rigidbody != null && GrabItemCooldown && hit.rigidbody.mass <= MaxWeight && hit.rigidbody.mass <= AbilityLevel)
        {
            GrabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
            CheckAbilityLevel(GrabbedRB);
            GrabItemCooldown = false;
        }
    }
    private void HoldObject()
    {
        if (GrabbedRB)
        {
            GrabbedRB.isKinematic = true;
            GrabbedRB.MovePosition(Vector3.Lerp(GrabbedRB.position, ObjectHolder.transform.position, Time.deltaTime * LerpSpeed));         
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
            GrabbedRB.AddForce(Camera.transform.forward * ThrowForce / GrabbedRB.mass, ForceMode.VelocityChange);
            GrabbedRB = null;
            StartCoroutine(ResetAbility());
        }
    }  
    private void IgnoreCollision()
    {
        if (GrabbedRB)
        {
            ObjectHeld = GrabbedRB.gameObject;
            GrabbedRB.GetComponent<Collider>().enabled = false;    
            ChangeAlpha(GrabbedRB.gameObject.GetComponent<Renderer>().material, AlphaTransparent);
        }
        else 
        {
            if (ObjectHeld != null) 
            {
                ObjectHeld.GetComponent<Collider>().enabled = true;
                ChangeAlpha(ObjectHeld.GetComponent<Renderer>().material, AlphaNonT);
            }         
        }
    }
    #endregion

    #region Secondary Components
    //Rendering mode of objects must be set to Transparent for this script to work.
    //Otherwise the changes will not be visible.
    private void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new (oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
    private IEnumerator ResetAbility()
    {
        yield return new WaitForSeconds(AbilityCooldownTimer);
        GrabItemCooldown = true;
    }
    #endregion  
}