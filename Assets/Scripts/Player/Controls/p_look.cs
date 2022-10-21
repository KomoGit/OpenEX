using UnityEngine;

public class p_look : MonoBehaviour
{
    //[SerializeField] private Transform camHolder; //Enable this and ensure that there is a script keeping camHolder from moving weirdly.
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform pBody;
    [SerializeField] private float SenX; // SENX And SENY must be moved to input manager once it is made.
    [SerializeField] private float SenY;
    private float xRotation;
    private float yRotation;
    private Vector2 mouseVector;

    private PControls _ctrl;

    void Awake()
    {
        _ctrl = new PControls();
        pBody = FindObjectOfType<p_movement>().transform;
    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        MouseLook();
        // OrientationRotation();
        // BodyRotation();
    }
    
    private void MouseLook()
    {
        mouseVector = _ctrl.Player.Mouse.ReadValue<Vector2>();
        float mouseX = mouseVector.x * SenX * Time.deltaTime;
        float mouseY = mouseVector.y * SenY * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        pBody.rotation = Quaternion.Euler(0,yRotation,0);
    }

    // private void OrientationRotation(){
    //     orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    // }
    // private void BodyRotation(){
    //     pBody.rotation = Quaternion.Euler(0,yRotation,0);
    // }

    //New Input System Boilerplate
    private void OnEnable() => _ctrl.Enable();
    private void OnDisable() => _ctrl.Disable();
}
