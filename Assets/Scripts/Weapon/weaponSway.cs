using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("MouseX") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("MouseY") * swayMultiplier;

        //calculate target rotation
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        //rotate

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime); Mathf.Clamp(0f,0f,0f) ;
    }
}
