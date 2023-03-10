using UnityEngine;

public class p_look : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform pBody;
    [SerializeField] private float SenX; // SENX And SENY must be moved to input manager once it is made.
    [SerializeField] private float SenY;
    private float xRotation;
    private float yRotation;

    void Awake()
    {
        pBody = FindObjectOfType<p_movement>().transform;
    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void MouseLook(Vector2 mouseVector)
    {
        //mouseVector = _ctrl.Player.Mouse.ReadValue<Vector2>();
        float mouseX = mouseVector.x * SenX * Time.deltaTime;
        float mouseY = mouseVector.y * SenY * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        pBody.rotation = Quaternion.Euler(0,yRotation,0);
    }
}
