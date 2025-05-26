using UnityEngine;
using UnityEngine.SceneManagement;
public class WrapZone : MonoBehaviour
{
    public int nextScene = 0;

    private void OnTriggerEnter(Collider other)
    {
     
        SceneManager.LoadScene(nextScene);
    }
}

