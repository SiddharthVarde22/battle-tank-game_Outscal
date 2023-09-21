using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderService : GenericSingleton<LevelLoaderService>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if((index + 1) <= SceneManager.sceneCountInBuildSettings)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
