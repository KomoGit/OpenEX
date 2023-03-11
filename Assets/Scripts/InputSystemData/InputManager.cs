using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PControls _ctrl;
    [SerializeField] private p_movement MovementScriptObject;
    [SerializeField] private p_look LookScriptObject;

  //  private float horizontalInput;
    //private float verticalInput;
 
    private void Awake()
    {
        _ctrl = new PControls();
        _ctrl.Player.Jump.started += _ => MovementScriptObject.Jump();
        _ctrl.Player.Crouch.started += _ => MovementScriptObject.Crouch();
        _ctrl.Player.Crouch.canceled += _ => MovementScriptObject.StopCrouch();
    }

    private void Update()
    {
        Vector2 mouseVector = _ctrl.Player.Mouse.ReadValue<Vector2>();
        LookScriptObject.MouseLook(mouseVector);
        MyInput();
    }

    private void FixedUpdate()
    {
        //OLD VERSION
        // MovementScriptObject.HandleMovement(horizontalInput,verticalInput);

    }

    private void MyInput()
    {
        //OLD VERSION
       //horizontalInput = _ctrl.Player.Movement.//_ctrl.Player.Movement.ReadValue<float>();
       //verticalInput = _ctrl.Player.Movement.ReadValue<float>();
    }

    //New input system boilerplate.
    private void OnEnable() => _ctrl.Enable();
    private void OnDisable() => _ctrl.Disable();
}
