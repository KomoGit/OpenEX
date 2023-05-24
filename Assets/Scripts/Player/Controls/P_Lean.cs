using UnityEngine;

public class P_Lean : MonoBehaviour
{
    [Header("Configures")]
    [SerializeField] private Transform LeanPivot;
    [SerializeField] private float CurrentLean;
    [SerializeField] private float TargetLean;
    [SerializeField] private float LeanAngle;
    [SerializeField] private float LeanSmoothing;
    [SerializeField] private float LeanVelocity;
    private void Update()
    {
        CalculateLean();
    }

    private void CalculateLean()
    {
        CurrentLean = Mathf.SmoothDamp(CurrentLean,TargetLean, ref LeanVelocity, LeanSmoothing);
        LeanPivot.localRotation = Quaternion.Euler(new Vector3(0, 0, CurrentLean));
    }

    private void LeanLeft()
    {
        CurrentLean = -LeanAngle;
    }
    private void LeanRight()
    {
        CurrentLean = LeanAngle;
    }
}
