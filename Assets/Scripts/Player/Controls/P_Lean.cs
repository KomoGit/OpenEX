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

    void Update()
    {
        CalculateLean();
    }
    public void LeanLeft()
    {
        TargetLean = LeanAngle;
    }
    public void LeanRight()
    {
        TargetLean = -LeanAngle;
    }
    public void CancelLean()
    {
        TargetLean = 0;
    }
    private void CalculateLean()
    {
        CurrentLean = Mathf.SmoothDamp(CurrentLean,TargetLean, ref LeanVelocity, LeanSmoothing);
        LeanPivot.localRotation = Quaternion.Euler(new Vector3(0, 0, CurrentLean));
    }
}
