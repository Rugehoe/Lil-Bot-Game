using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(player.transform.position.x,player.transform.position.y-4.5f, -6);

    }
}