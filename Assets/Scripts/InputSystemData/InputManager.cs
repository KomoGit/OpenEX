using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PControls _ctrl;
    [SerializeField] private p_movement MovementScriptObject;
    [SerializeField] private p_look LookScriptObject;

 
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

    private void MyInput()
    {
        Vector2 playerVector = _ctrl.Player.Movement.ReadValue<Vector2>();
        MovementScriptObject.HandleMovement(playerVector);
    }

    //New input system boilerplate.
    private void OnEnable() => _ctrl.Enable();
    private void OnDisable() => _ctrl.Disable();
}
