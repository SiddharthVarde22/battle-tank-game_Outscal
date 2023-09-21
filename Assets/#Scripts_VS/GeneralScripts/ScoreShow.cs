using UnityEngine;
using TMPro;

public class ScoreShow : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        gameOverText.text = "Game Over!!!\nScore - " + ScoreService.Instance.PlayerScore;
    }
}
