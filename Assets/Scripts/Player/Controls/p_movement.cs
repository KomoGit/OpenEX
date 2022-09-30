using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class p_movement : MonoBehaviour
{
    [Header("Player Configures")]
    [SerializeField] private PlayerStates playerState;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform orientation;
    [Header("Speed and Force")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float silentWalkSpeed;
    [SerializeField] private float maxForce;
    [Header("Jump and Crouch")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float crouchYScale;
    private Transform playerTransform;
    private Vector2 moveDirection;
    private float startYScale;
    private Rigidbody _rb;
    private PControls _ctrl;
    private float movement;
    
    private bool isGrounded => Physics.Raycast(transform.position,Vector3.down,1.2f,whatIsGround);
    //These two booleans are used for state machine. But I think they are redundant so best to find a better way to replace them
    private bool isWalking => movement != 0;
    
    void Awake()
    {
        _ctrl = new PControls();
        _rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();

        _rb.freezeRotation = true;
        startYScale  = playerTransform.localScale.y;
        //New Input System. TODO: Move this into InputManager.
        _ctrl.Player.Jump.started += _ => Jump();
        _ctrl.Player.Crouch.started += _ => Crouch();
        _ctrl.Player.Crouch.canceled += _ => StopCrouch();
    }
    private void Update()
    {
        StateHandler();
    }
    private void FixedUpdate()
    {
        handleMovement();
    }
    //Crouching and Jumping works now.
    //TODO: Create Walking.
    private enum PlayerStates
    {
        IDLE,
        WALKING,
        AIR,
        CROUCHING,
        SILENTWALKING
    }
    // Add rest of the states in state handler.
    public void StateHandler()
    {
        if(!isWalking && isGrounded){
            playerState = PlayerStates.IDLE;
        }
        else{
            playerState = PlayerStates.AIR;
        }
    }
    //Will be used in abilities. It will allow us to change speed or jump force on duration of ability being used.
    public void setData(string index,float change)
    {
        string formattedIndex = index.ToLower();
        switch(formattedIndex){
            case "movementspeed":
            movementSpeed = change;
            break;

            case "jumpforce":
            jumpForce = change;
            break;

            case "silentwalkspeed":
            silentWalkSpeed = change;
            break;

            default:
            Debug.Log("Data: " + index + " not found.");
            break;
        }
    }
    private void handleMovement()
    {
        
    }
    private void Jump()
    {
        if(isGrounded){
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void Crouch()
    {
        var currentYScale = crouchYScale;
        playerTransform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        if (isGrounded) _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); 
    }
    private void StopCrouch()
    {
        playerTransform.localScale = new Vector3(transform.localScale.x, startYScale, 1);
    }
    //New input boilerplate.
    private void OnEnable() => _ctrl.Enable();
    private void OnDisable() => _ctrl.Disable();
}
