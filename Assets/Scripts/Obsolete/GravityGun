using UnityEngine;

public class GravityGun : MonoBehaviour
{  
    [Header("References")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform objectHolder;
    [SerializeField] private Transform Player; //Although it is still assigned, 108 of this code still gives error as it says it is not assigned. It gets fixed as soon as the user interacts with an object.
    //[NonSerialized] public KeyCode interactKey;
    //[SerializeField] AudioSource m_AudioSource;


    [Header("Audio")]
    //[SerializeField] private AudioClip nullSound;

    [Header("Values")]
    [SerializeField] private float maxGrabDistance = 10f;
    [SerializeField] private float maxWeight = 5f;
    [SerializeField] private float lerpSpeed = 100f;
    [SerializeField] private float throwForce = 20f;


    private GameObject heldObject = default;
    public bool GravityGunActive;
    [SerializeField] private Rigidbody grabbedRB;

    float AlphaNonT = 1f, AlphaTransparent = 0.5f; //NonT is the value of non transparency,AlphaTransparent is the value of transparency

   /* private void Start()
    {
        m_AudioSource.GetComponent<AudioSource>();
        //inputManager = FindObjectOfType<InputManager>();
    }*/
    void Update()
    {
        holdObject();
        checkObject();
        IgnorePlayer();
    }
    public void checkObject()
    {
        if (grabbedRB)
        {
            grabbedRB.isKinematic = false;
            grabbedRB = null;
            GravityGunActive = false;
        }
        else
        {
            RaycastHit hit;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out hit, maxGrabDistance))
            {
                grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (grabbedRB)
                {
                    grabbedRB.isKinematic = true;
                    GravityGunActive = true;
                }
            }
        }
    }
    private void holdObject()
    {
        if (grabbedRB && grabbedRB.mass <= maxWeight)
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));
            if (Input.GetMouseButtonDown(0))
            {
                grabbedRB.isKinematic = false;
                GravityGunActive = false;
                grabbedRB.AddForce(cam.transform.forward * throwForce / grabbedRB.mass, ForceMode.VelocityChange);
                grabbedRB = null;
            }
        }
        else if (grabbedRB && grabbedRB.mass >= maxWeight)
        {
            GravityGunActive = false;
            grabbedRB.isKinematic = false;
        }
    }
    private void IgnorePlayer()
    {
        if (GravityGunActive == true)
        {
            Physics.IgnoreCollision(grabbedRB.GetComponent<Collider>(), Player.GetComponent<Collider>());
            heldObject = grabbedRB.gameObject;
            ChangeAlpha(grabbedRB.gameObject.GetComponent<Renderer>().material, AlphaTransparent); //Changes the transparency
        }
        else
        {
            if(heldObject == null)
            {
                return;
            }
            else
            {
                Physics.IgnoreCollision(heldObject.GetComponent<Collider>(), Player.GetComponent<Collider>(), false);
                ChangeAlpha(heldObject.GetComponent<Renderer>().material, AlphaNonT);
            }
        }
    }
    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }

    /*private void PlayNullSound()
    {
            m_AudioSource.clip = nullSound;
            m_AudioSource.Play();
    }*/
}
