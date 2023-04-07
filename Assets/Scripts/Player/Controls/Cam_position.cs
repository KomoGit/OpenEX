using UnityEngine;

[RequireComponent(typeof(Flashlight))]
[RequireComponent(typeof(CarryObject))]
[RequireComponent(typeof(P_Interact))]
public class Cam_position : MonoBehaviour
{
    [SerializeField] private Transform _player;
    void Update()
    {
        //transform.position = _player.position;
        Vector3 newPosition = new(_player.position.x, transform.position.y, _player.position.z);
        transform.position = newPosition;
    }
}
