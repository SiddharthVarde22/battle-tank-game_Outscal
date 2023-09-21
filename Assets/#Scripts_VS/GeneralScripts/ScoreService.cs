using UnityEngine;

public class ScoreService : GenericSingleton<ScoreService>
{
    public int PlayerScore { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void ResetPlayerScore()
    {
        PlayerScore = 0;
    }

    public void IncreasePlayerScore(int score)
    {
        PlayerScore += score;
    }
}
