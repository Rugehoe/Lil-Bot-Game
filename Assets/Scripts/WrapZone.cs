using UnityEngine;
using UnityEngine.SceneManagement;
public class WrapZone : MonoBehaviour
{
    public int nextScene = 0;
    public bool end = false;

    [SerializeField]
    GameObject loreTab;

    private void OnTriggerEnter(Collider other)
    {
        if (!end) SceneManager.LoadScene(nextScene);
        if (end) loreTab.SetActive(true);
    }
}

