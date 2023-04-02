using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerAudio))]
public class P_movement : MonoBehaviour
{
    [Header("Player Configures")]
    [SerializeField] private PlayerStates playerState;
    [SerializeField] private RaycastHit slopeHit;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] public Transform orientation;
    [Header("Speed and Force")]
    [SerializeField] private float regularMovementSpeed;
    [SerializeField] private float silentMovementSpeed;
    [SerializeField] private float groundDrag;
    [Header("Jump and Crouch")]
    [SerializeField] private float coyoteTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private float crouchYScale;
    [Header("Slope Handling")]
    [SerializeField] private float slopeAdjustedMass;
    [SerializeField] private float defaultMass;
    [SerializeField] private float playerHeight;
    [SerializeField] private float maxSlopeAngle;
    private Transform playerTransform;
    private Rigidbody _rb;
    private Vector3 moveDirection;
    private float startYScale;
    private float currentMovementSpeed;
    public bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, 1.2f, whatIsGround);
    [HideInInspector] public bool IsWalking => InputManager.PlayerVector != Vector2.zero; //_rb.velocity.x != 0;
    [HideInInspector] public bool IsCrouching = false;
    [HideInInspector] public bool IsSilentWalking = false;
    private bool CoyoteTimerActive = false;
    void Awake()
    {
        currentMovementSpeed = regularMovementSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        playerTransform = GetComponent<Transform>();
        startYScale  = playerTransform.localScale.y;
    }
    private void Update()
    {
        _rb.useGravity = !OnSlope();
        if (IsGrounded) _rb.drag = groundDrag;
        else
        {
            _rb.drag = 0;
        }
        if (OnSlope())
        {
            _rb.mass = slopeAdjustedMass;
        }
        else
        {
            _rb.mass = defaultMass;
        }
        StateHandler();
        SpeedControl();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!IsGrounded)
        {
            CoyoteTimerActive = true;
            Invoke(nameof(DisableCoyoteTimer), coyoteTime);
        }
    }
    public enum PlayerStates
    {
        IDLE,
        WALKING,
        AIR,
        CROUCHING,
        SILENTWALKING,
        SWIMMING
    }
    // The states written here are only for debug purposes. In prod code, these can be safely removed.
    public void StateHandler()
    {
        if(!IsWalking && IsGrounded){
            playerState = PlayerStates.IDLE;
        }
        else if (IsCrouching)
        {
            playerState = PlayerStates.CROUCHING;
        }
        else if (IsWalking && !IsSilentWalking)
        {
            playerState = PlayerStates.WALKING;
        }
        else if (IsSilentWalking)
        {
            playerState = PlayerStates.SILENTWALKING;
        }
        else
        {
            playerState = PlayerStates.AIR;
        }
    }
    public void HandleMovement(Vector2 input)
    {
        moveDirection = Vector3.zero;
        moveDirection = orientation.forward * input.y + orientation.right * input.x;
        _rb.AddForce(10f * currentMovementSpeed * moveDirection.normalized,ForceMode.Force);
    }
    public void HandleMovement(Vector3 direction)
    {
        _rb.AddForce(20f * currentMovementSpeed * direction.normalized, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new(_rb.velocity.x,0f,_rb.velocity.z);

        if(flatVel.magnitude > currentMovementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentMovementSpeed;
            _rb.velocity = new Vector3(limitedVel.x,_rb.velocity.y,limitedVel.z);
        }
    }
    public void Jump()
    {
        if(IsGrounded || CoyoteTimerActive){
            _rb.mass = defaultMass;
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void Crouch()
    {
        IsCrouching = true;
        currentMovementSpeed = silentMovementSpeed;
        playerTransform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        if (IsGrounded) _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); 
    }
    public void StopCrouch()
    {
        IsCrouching = false;
        currentMovementSpeed = regularMovementSpeed;
        playerTransform.localScale = new Vector3(transform.localScale.x, startYScale, 1);
    }
    public void SilentWalk()
    {
        IsSilentWalking = true;
        currentMovementSpeed = silentMovementSpeed;
    }

    public void StopSilentWalk()
    {
        IsSilentWalking = false;
        currentMovementSpeed = regularMovementSpeed; 
    }
    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position,Vector3.down,out slopeHit,playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up,slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }
    public Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }
    private void DisableCoyoteTimer()
    {
        CoyoteTimerActive = false;
    }
}
