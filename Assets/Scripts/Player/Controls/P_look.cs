using UnityEngine;

public class P_look : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform pBody;
    [SerializeField] private CarryObject carryObject;
    [SerializeField] private float SenX; 
    [SerializeField] private float SenY;
    public float xRotation { get; private set; }
    private float yRotation;

    void Awake()
    {
        pBody = FindObjectOfType<P_movement>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void MouseLook(Vector2 mouseVector)
    {
        float mouseX = mouseVector.x * Time.deltaTime * SenX;
        float mouseY = mouseVector.y * Time.deltaTime * SenY;

        xRotation -= mouseY;
        yRotation += mouseX;
        if (carryObject._grabbedRB)
        {
            xRotation = Mathf.Clamp(xRotation, -40f, 40f);
        }
        else
        {
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }
        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        pBody.rotation = Quaternion.Euler(0,yRotation,0);
    }
}
