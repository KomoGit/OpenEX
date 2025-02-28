using UnityEngine;

public class P_Lean : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform Camera; // The object holding the camera
    

    [Header("Lean Settings")]
    [SerializeField][Range(0.1f, 1f)] private float leanDistance = 0.5f; // Horizontal lean distance
    [SerializeField][Range(5f, 30f)] private float leanAngle = 15f; // Rotation angle for leaning effect
    [SerializeField][Range(1f, 20f)] private float leanSpeed = 12f; // Smoothness of the lean transition

    private Vector3 originalCameraPos;
    private float targetLean;
    private float currentLean;

    private void Awake()
    {
        Camera = this.gameObject.transform;
    }

    void Start()
    {
        // Cache the original position of the camera holder
        originalCameraPos = Camera.localPosition;
    }

    void LateUpdate()
    {
        // Smoothly interpolate the lean amount
        currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

        // Calculate horizontal lean offset in root's local space
        Vector3 leanOffset = currentLean * leanDistance * transform.right;
        leanOffset.y = 0; // Ensure no vertical movement

        // Apply the lean offset to the camera's position
        Camera.localPosition = originalCameraPos + leanOffset;

        // Apply the lean tilt as a Z-axis rotation (around the camera's forward axis)
        Quaternion leanRotation = Quaternion.Euler(0, 0, -currentLean * leanAngle);

        // Combine the lean tilt with the existing rotation
        Camera.localRotation = leanRotation;
    }

    // Input system methods
    public void OnLeftLean() => targetLean = -1f;
    public void OnRightLean() => targetLean = 1f;
    public void OnStopLean() => targetLean = 0f;
}