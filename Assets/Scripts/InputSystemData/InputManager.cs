using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PControls _ctrl;
    [SerializeField] private P_Interact InteractWithObject;
    [SerializeField] private ResetBiocharge ResetCharge;
    [SerializeField] private CarryObject CarryObject;
    [SerializeField] private Flashlight FlashlightObject;
    [SerializeField] private Agility AgilityObject;
    [SerializeField] private P_movement MovementScriptObject;
    [SerializeField] private P_Lean PlayerLeanObject;
    [SerializeField] private P_look LookScriptObject;
    public bool AllowPlayerMovement { private get; set; } = true;
    public static Vector2 PlayerVector { get; private set; } //Not sure if this is spaghetti code, but this is being accessed by p_movement where it is accessed by this script.
    private void Awake()
    {
        _ctrl = new PControls();
        #region Leaning
        _ctrl.Player.LeanLeft.performed += _ => PlayerLeanObject.OnLeftLean();
        _ctrl.Player.LeanLeft.canceled += _ => PlayerLeanObject.OnStopLean();
        _ctrl.Player.LeanRight.canceled += _ => PlayerLeanObject.OnStopLean();
        _ctrl.Player.LeanRight.performed += _ => PlayerLeanObject.OnRightLean();
        #endregion
        _ctrl.Player.Jump.started += _ => MovementScriptObject.Jump();
        _ctrl.Player.Interact.started += _ => CarryObject.AbilityActivate();
        #region Crouch
        _ctrl.Player.Crouch.started += _ => MovementScriptObject.Crouch();
        _ctrl.Player.Crouch.canceled += _ => MovementScriptObject.StopCrouch();
        #endregion
        #region Silent Walk
        _ctrl.Player.SilentWalk.started += _ => MovementScriptObject.SilentWalk();
        _ctrl.Player.SilentWalk.canceled += _ => MovementScriptObject.StopSilentWalk();
        #endregion
        _ctrl.DebugKeys.ResetEnergy.started += _ => ResetCharge.SetEnergyFull();
        //Abilities 
        _ctrl.Abilities.Flashlight.started += _ => FlashlightObject.AbilityActivate();
        _ctrl.Abilities.SpeenEnhancmentRunSilent.started += _ => AgilityObject.AbilityActivate();
        _ctrl.Player.Interact.started += _ => InteractWithObject.CheckInteractiveObject();
        _ctrl.Player.Shoot.started += _ => CarryObject.ThrowObject();
    }
    private void Update()
    {
        Vector2 mouseVector = _ctrl.Player.Mouse.ReadValue<Vector2>();
        if (AllowPlayerMovement)
        {
            LookScriptObject.MouseLook(mouseVector);
        }     
        if (MovementScriptObject.IsGrounded && AllowPlayerMovement) 
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
