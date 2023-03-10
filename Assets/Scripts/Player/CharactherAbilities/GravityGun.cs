using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{  
    [Header("References")]
    [SerializeField] Camera cam;
    [SerializeField] Transform objectHolder;
    [SerializeField] Transform Player; //Although it is still assigned, 108 of this code still gives error as it says it is not assigned. It gets fixed as soon as the user interacts with an object.
    [NonSerialized] public KeyCode interactKey;
    [SerializeField] AudioSource m_AudioSource;
    //InputManager inputManager; //Always Assign an input manager and inherit button codes from this script. IManager should always be present in levels, it is made into a prefab at the moment.


    [Header("Audio")]
    [SerializeField] private AudioClip nullSound;

    [Header("Values")]
    [SerializeField] float maxGrabDistance = 10f;
    [SerializeField] float maxWeight = 5f;
    [SerializeField] float lerpSpeed = 100f;
    [SerializeField] float throwForce = 20f;


    GameObject heldObject = default;
    [NonSerialized] public bool GravityGunActive;
    [NonSerialized] public Rigidbody grabbedRB;

    float AlphaNonT = 1f, AlphaTransparent = 0.5f; //NonT is the value of non transparency,AlphaTransparent is the value of transparency

    private void Start()
    {
        m_AudioSource.GetComponent<AudioSource>();
        //inputManager = FindObjectOfType<InputManager>();
    }
    void Update()
    {
        //Keys();
        holdObject();
        checkObject();
        IgnorePlayer();
    }
    public void checkObject()
    {
        if (Input.GetKeyDown(interactKey))
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
                        Debug.Log(grabbedRB.mass);
                    }
                }
                else
                {
                    PlayNullSound();
                }
            }       
        }
    }
    public void holdObject()
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
    /*private void Keys()
    {
        interactKey = inputManager.interactKey;
    }*/
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

    private void PlayNullSound()
    {
            m_AudioSource.clip = nullSound;
            m_AudioSource.Play();
    }
}
