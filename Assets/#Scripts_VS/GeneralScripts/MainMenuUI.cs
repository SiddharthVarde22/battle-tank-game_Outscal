using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Button playButton, quitButton;
    // Start is called before the first frame update
    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonPressed);
        quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    public void OnPlayButtonPressed()
    {
        LevelLoaderService.Instance.LoadScene(1);
    }

    public void OnQuitButtonPressed()
    {
        LevelLoaderService.Instance.QuitGame();
    }
}
