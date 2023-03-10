using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PControls _ctrl;
    [SerializeField] private p_movement _player;
    [SerializeField] private p_look p_Look;
 
    private void Awake()
    {
        _ctrl = new PControls();
        _ctrl.Player.Jump.started += _ => _player.Jump();
        _ctrl.Player.Crouch.started += _ => _player.Crouch();
        _ctrl.Player.Crouch.canceled += _ => _player.StopCrouch();
    }

    private void Update()
    {
        Vector2 mouseVector = _ctrl.Player.Mouse.ReadValue<Vector2>();
        p_Look.MouseLook(mouseVector);
    }

    //New input system boilerplate.
    private void OnEnable() => _ctrl.Enable();
    private void OnDisable() => _ctrl.Disable();
}
