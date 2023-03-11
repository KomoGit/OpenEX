using UnityEngine;

public class p_look : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform pBody;
    [SerializeField] private float SenX; 
    [SerializeField] private float SenY;
    private float xRotation;
    private float yRotation;

    void Awake()
    {
        pBody = FindObjectOfType<p_movement>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void MouseLook(Vector2 mouseVector)
    {
        float mouseX = mouseVector.x * Time.deltaTime * SenX;
        float mouseY = mouseVector.y * Time.deltaTime * SenY;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0);//xRotation
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        pBody.rotation = Quaternion.Euler(0,yRotation,0);
    }
}
