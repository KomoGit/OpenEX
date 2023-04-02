using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PControls _ctrl;
    [SerializeField] private ResetBiocharge ResetCharge;
    [SerializeField] private CarryObject CarryObject;
    [SerializeField] private Flashlight FlashlightObject;
    [SerializeField] private P_movement MovementScriptObject;
    [SerializeField] private P_look LookScriptObject;
    public static Vector2 PlayerVector { get; private set; } //Not sure if this is spaghetti code, but this is being accessed by p_movement where it is accessed by this script.


    private void Awake()
    {
        _ctrl = new PControls();
        _ctrl.Player.Jump.started += _ => MovementScriptObject.Jump();
        _ctrl.Player.Interact.started += _ => CarryObject.AbilityActivate();
        _ctrl.Player.Shoot.started += _ => CarryObject.ThrowObject();
        _ctrl.Player.Crouch.started += _ => MovementScriptObject.Crouch();
        _ctrl.Player.Crouch.canceled += _ => MovementScriptObject.StopCrouch();
        _ctrl.Abilities.Flashlight.started += _ => FlashlightObject.AbilityActivate();
        _ctrl.Player.SilentWalk.started += _ => MovementScriptObject.SilentWalk();
        _ctrl.Player.SilentWalk.canceled += _ => MovementScriptObject.StopSilentWalk();
        _ctrl.DebugKeys.ResetEnergy.started += _ => ResetCharge.SetEnergyFull();
    }
    private void Update()
    {
        Vector2 mouseVector = _ctrl.Player.Mouse.ReadValue<Vector2>();
        LookScriptObject.MouseLook(mouseVector);
        if (MovementScriptObject.IsGrounded) 
        {
            MyInput();
        }
    }
    private void MyInput()
    {
        PlayerVector = _ctrl.Player.Movement.ReadValue<Vector2>();
        if (MovementScriptObject.OnSlope())
        {
            MovementScriptObject.HandleMovement(MovementScriptObject.GetSlopeMoveDirection());
        }
        MovementScriptObject.HandleMovement(PlayerVector);
    }
    //New input system boilerplate.
    private void OnEnable() => _ctrl.Enable();
    private void OnDisable() => _ctrl.Disable();
}
