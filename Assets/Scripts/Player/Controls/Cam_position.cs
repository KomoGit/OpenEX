using UnityEngine;
public class Cam_position : MonoBehaviour
{
    [SerializeField] private Transform Player;
    void Update()
    {
        transform.position = Player.position;
    }
}
