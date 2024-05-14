using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyScenechange : MonoBehaviour
{
    public string sceneToLoad;
    private void OnDestroy()
    {
        
        Debug.Log("GameObject has been destroyed!");
        // Perform additional cleanup or notification actions here
        //SceneManager.LoadScene(sceneToLoad);
    }
}
