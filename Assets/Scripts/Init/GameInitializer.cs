using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public string setupSceneName;

    void Awake() {
        setPlayerPrefs();
        if (!(PlayerPrefs.GetInt("setupCompleted") == 1)) SceneManager.LoadScene(setupSceneName);
    }

    private void setPlayerPrefs() {

    }
}
