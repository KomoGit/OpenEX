using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerAudio))]
public class P_movement : MonoBehaviour
{
    [Header("Player Configures")]
    [SerializeField] private PlayerStates PlayerState;
    [SerializeField] private RaycastHit SlopeHit;
    [SerializeField] private LayerMask WhatIsGround;
    public Transform Orientation;
    [Header("Speed and Force")]
    [SerializeField] private float RegularMovementSpeed;
    [SerializeField] private float SilentMovementSpeed;
    [SerializeField] private float GroundDrag;
    [Header("Jump and Crouch")]
    [SerializeField] private float CoyoteTime;
    [SerializeField] private float RegularJumpForce;
    [SerializeField] private float CrouchYScale;
    [Header("Slope Handling")]
    [SerializeField] private float SlopeAdjustedMass;
    [SerializeField] private float DefaultMass;
    [SerializeField] private float PlayerHeight;
    [SerializeField] private float MaxSlopeAngle;
    private Transform PlayerTransform;
    private Rigidbody RigidBody;
    private Vector3 MoveDirection;
    private float StartYScale; 
    public bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, 1.2f, WhatIsGround);
    public bool IsWalking => InputManager.PlayerVector != Vector2.zero;
    [HideInInspector] public bool IsCrouching = false;
    [HideInInspector] public bool IsSilentWalking = false;
    [HideInInspector] public float CurrentMovementSpeed;
    [HideInInspector] public float CurrentJumpForce;
    private bool CoyoteTimerActive = false;
    void Awake()
    {
        CurrentMovementSpeed = RegularMovementSpeed;
        CurrentJumpForce = RegularJumpForce;
        RigidBody = GetComponent<Rigidbody>();
        RigidBody.freezeRotation = true;
        PlayerTransform = GetComponent<Transform>();
        StartYScale  = PlayerTransform.localScale.y;
    }
    private void Update()
    {
        RigidBody.useGravity = !OnSlope();
        if (IsGrounded) RigidBody.drag = GroundDrag;
        else
        {
            RigidBody.drag = 0;
        }
        if (OnSlope())
        {
            RigidBody.mass = SlopeAdjustedMass;
        }
        else
        {
            RigidBody.mass = DefaultMass;
        }
        StateHandler();
        SpeedControl();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!IsGrounded)
        {
            CoyoteTimerActive = true;
            Invoke(nameof(DisableCoyoteTimer), CoyoteTime);
        }
    }
    #region States,StateHandler
    public enum PlayerStates
    {
        IDLE,
        WALKING,
        AIR,
        CROUCHING,
        SILENTWALKING,
        SWIMMING
    }
    public void StateHandler()
    {
        if(!IsWalking && IsGrounded){
            PlayerState = PlayerStates.IDLE;
        }
        else if (IsCrouching)
        {
            PlayerState = PlayerStates.CROUCHING;
        }
        else if (IsWalking && !IsSilentWalking)
        {
            PlayerState = PlayerStates.WALKING;
        }
        else if (IsSilentWalking)
        {
            PlayerState = PlayerStates.SILENTWALKING;
        }
        else
        {
            PlayerState = PlayerStates.AIR;
        }
    }
    #endregion
    #region Movement
    public void HandleMovement(Vector2 input)
    {
        MoveDirection = Vector3.zero;
        MoveDirection = Orientation.forward * input.y + Orientation.right * input.x;
        RigidBody.AddForce(10f * CurrentMovementSpeed * MoveDirection.normalized,ForceMode.Force);
    }
    public void HandleMovement(Vector3 direction)
    {
        RigidBody.AddForce(20f * CurrentMovementSpeed * direction.normalized, ForceMode.Force);
    } 
    private void SpeedControl()
    {
        Vector3 flatVel = new(RigidBody.velocity.x,0f,RigidBody.velocity.z);

        if(flatVel.magnitude > CurrentMovementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * CurrentMovementSpeed;
            RigidBody.velocity = new Vector3(limitedVel.x,RigidBody.velocity.y,limitedVel.z);
        }
    }
    #endregion
    #region Jump
    public void Jump()
    {
        if(IsGrounded || CoyoteTimerActive){
            RigidBody.mass = DefaultMass;
            RigidBody.velocity = new Vector3(RigidBody.velocity.x, 0f, RigidBody.velocity.z);
            RigidBody.AddForce(transform.up * CurrentJumpForce, ForceMode.Impulse);
            CoyoteTimerActive = false;
        }
    }
    private void DisableCoyoteTimer()
    {
        CoyoteTimerActive = false;
    }
    #endregion
    #region Crouching
    public void Crouch()
    {
        IsCrouching = true;
        CurrentMovementSpeed = SilentMovementSpeed;
        PlayerTransform.localScale = new Vector3(transform.localScale.x, CrouchYScale, transform.localScale.z);
        if (IsGrounded) RigidBody.AddForce(Vector3.down * 5f, ForceMode.Impulse); 
    }
    public void StopCrouch()
    {
        IsCrouching = false;
        CurrentMovementSpeed = RegularMovementSpeed;
        PlayerTransform.localScale = new Vector3(transform.localScale.x, StartYScale, 1);
    }
    #endregion
    #region SilentWalk
    public void SilentWalk()
    {
        IsSilentWalking = true;
        CurrentMovementSpeed = SilentMovementSpeed;
    }
    public void StopSilentWalk()
    {
        IsSilentWalking = false;
        if(PlayerState == PlayerStates.CROUCHING)
        {
            CurrentMovementSpeed = SilentMovementSpeed;
        }
        else
        {
            CurrentMovementSpeed = RegularMovementSpeed;
        }     
    }
    #endregion
    #region Slope
    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position,Vector3.down,out SlopeHit,PlayerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up,SlopeHit.normal);
            return angle < MaxSlopeAngle && angle != 0;
        }
        return false;
    }
    public Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(MoveDirection, SlopeHit.normal);
    }
    #endregion
}