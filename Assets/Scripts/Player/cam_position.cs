using UnityEngine;

public class cam_position : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    void Update()
    {
        transform.position = _camera.position;
    }
}
