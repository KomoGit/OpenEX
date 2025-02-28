using UnityEngine;

public class P_Lean : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraHolder; // Parent object of the camera
    [SerializeField] private Transform orientation;  // Reference to the orientation object

    [Header("Lean Settings")]
    [SerializeField][Range(0.1f, 1f)] private float leanDistance = 0.5f;
    [SerializeField][Range(5f, 30f)] private float leanAngle = 15f;
    [SerializeField][Range(1f, 20f)] private float leanSpeed = 12f;

    private float targetLean;
    private float currentLean;

    private void Awake()
    {
        if (cameraHolder == null)
            cameraHolder = transform; // Default to this object if not set
    }

    void LateUpdate()
    {
        // Smoothly interpolate the lean amount
        currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

        // **Determine which axis to modify based on player's view direction**
        float forwardDot = Vector3.Dot(orientation.forward, Vector3.forward);
        bool isFacingForwardOrBackward = Mathf.Abs(forwardDot) > 0.5f; // Forward or Backward

        // **Calculate lean offset always using orientation.right**
        Vector3 leanOffset = currentLean * leanDistance * orientation.right;
        leanOffset.y = 0; // Prevent vertical movement

        // Apply position offset to cameraHolder
        cameraHolder.position = transform.position + leanOffset;

        // **Determine the correct tilt axis**
        Quaternion leanRotation;
        if (isFacingForwardOrBackward)
        {
            // **Facing Forward/Backward → Rotate around Z (tilt left/right)**
            leanRotation = Quaternion.Euler(0, 0, -currentLean * leanAngle);
        }
        else
        {
            // **Facing Left/Right → Rotate around X (tilt forward/backward)**
            leanRotation = Quaternion.Euler(-currentLean * leanAngle, 0, 0);
        }

        // Apply rotation while preserving original orientation
        cameraHolder.localRotation = leanRotation;
    }

    // Input system methods
    public void OnLeftLean() => targetLean = -1f;
    public void OnRightLean() => targetLean = 1f;
    public void OnStopLean() => targetLean = 0f;
}
