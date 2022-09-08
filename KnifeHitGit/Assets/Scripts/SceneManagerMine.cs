using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMine : MonoBehaviour
{
    public void LoadChangeKnife() {
        StartTheTime();
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        StartTheTime();
        SceneManager.LoadScene(0);
    }

    private static void StartTheTime() =>
        Time.timeScale = 1;
}
