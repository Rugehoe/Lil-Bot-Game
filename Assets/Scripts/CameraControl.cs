using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float speed = 3.0f;
    [SerializeField]
    float[] offset = new float[3];

    private void FixedUpdate()
    {
        Vector3 playerpoint = new Vector3(player.transform.position.x + offset[0], player.transform.position.y + offset[1], player.transform.position.z + offset[2]); 
        this.transform.Translate((playerpoint - this.transform.position) * speed * Time.deltaTime); 

    }
}