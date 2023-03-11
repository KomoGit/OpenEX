using UnityEngine;

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
    [SerializeField] private float groundDrag;
    //[SerializeField] private float maxForce;
    [Header("Jump and Crouch")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float crouchYScale;

    private Transform playerTransform;
    private Rigidbody _rb;
    private Vector2 moveDirection;
    private float startYScale;
    private float movement;

    //These two booleans are used for state machine. But I think they are redundant so best to find a better way to replace them
    private bool isGrounded => Physics.Raycast(transform.position,Vector3.down,1.2f,whatIsGround);
    private bool isWalking => movement != 0;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();

        _rb.freezeRotation = true;
        startYScale  = playerTransform.localScale.y;
    }
    private void Update()
    {
        if (isGrounded) _rb.drag = groundDrag;
        StateHandler();
        SpeedControl();
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
    public void SetData(string index,float change)
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
    //public void HandleMovement(float horizontalInput ,float verticalInput)
    public void HandleMovement(Vector2 input)
    {
        // moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // moveDirection = orientation.forward * verticalInput + orientation.right * verticalInput;
        moveDirection.x = input.x;
        moveDirection.y = input.y;
        _rb.AddForce(moveDirection.normalized * movementSpeed * 10f,ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.velocity.x,0f,_rb.velocity.z);

        if(flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            _rb.velocity = new Vector3(limitedVel.x,_rb.velocity.y,limitedVel.z);
        }
    }
    public void Jump()
    {
        if(isGrounded){
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void Crouch()
    {
        playerTransform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        if (isGrounded) _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); 
    }
    public void StopCrouch()
    {
        playerTransform.localScale = new Vector3(transform.localScale.x, startYScale, 1);
    }
}
