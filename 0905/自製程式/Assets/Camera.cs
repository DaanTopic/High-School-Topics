using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    private void Update()
    {
        transform.position = Player.position + offset;
    }
}
