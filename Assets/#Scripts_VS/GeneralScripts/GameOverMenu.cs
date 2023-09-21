using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    Button restartButton, mainMenuButton;

    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartPressed);
        mainMenuButton.onClick.AddListener(OnMainMenuPressed);
    }

    public void OnRestartPressed()
    {
        LevelLoaderService.Instance.LoadScene(1);
    }

    public void OnMainMenuPressed()
    {
        LevelLoaderService.Instance.LoadScene(0);
    }
}
