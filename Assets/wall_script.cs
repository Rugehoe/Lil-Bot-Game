using UnityEngine;

public class wall_script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.enabled = false;
    }
}
