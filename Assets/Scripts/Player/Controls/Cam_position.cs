using UnityEngine;

[RequireComponent(typeof(Flashlight))]
[RequireComponent(typeof(CarryObject))]
[RequireComponent(typeof(P_Interact))]
public class Cam_position : MonoBehaviour
{
    [SerializeField] private Transform Player;
    void Update()
    {
        transform.position = Player.position;
    }
}
