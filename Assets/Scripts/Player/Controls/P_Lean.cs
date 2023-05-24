using UnityEngine;

public class P_Lean : MonoBehaviour
{
    [Header("Configures")]
    [SerializeField] private Transform LeanPivot;
    [SerializeField] private float LeanAngle;
    [SerializeField] private float LeanSmoothing;
    private float LeanVelocity;
    private float CurrentLean;
    private float TargetLean;
    private void Update()
    {
        CalculateLean();
    }

    private void CalculateLean()
    {
        CurrentLean = Mathf.SmoothDamp(CurrentLean,TargetLean, ref LeanVelocity, LeanSmoothing);
        LeanPivot.localRotation = Quaternion.Euler(new Vector3(0, 0, CurrentLean));
    }

    public void LeanLeft()
    {
        CurrentLean = LeanAngle;
    }
    public void LeanRight()
    {
        CurrentLean = -LeanAngle;
    }
}
