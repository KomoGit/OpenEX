using UnityEngine;

public class P_look : MonoBehaviour
{
    [SerializeField] private Transform Orientation;
    [SerializeField] private Transform Player;
    [SerializeField] private CarryObject CarryObject;
    [SerializeField] private float SenX; 
    [SerializeField] private float SenY;
    public float XRotation { get; private set; }
    private float YRotation;

    void Awake()
    {
        Player = FindObjectOfType<P_movement>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void MouseLook(Vector2 mouseVector)
    {
        float mouseX = mouseVector.x * Time.deltaTime * SenX;
        float mouseY = mouseVector.y * Time.deltaTime * SenY;

        XRotation -= mouseY;
        YRotation += mouseX;
        if (CarryObject.GrabbedRB)
        {
            XRotation = Mathf.Clamp(XRotation, -40f, 40f);
        }
        else
        {
            XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        }
        transform.localRotation = Quaternion.Euler(XRotation,YRotation,0);
        Orientation.rotation = Quaternion.Euler(0, YRotation, 0);
        Player.rotation = Quaternion.Euler(0,YRotation,0);
    }
}
