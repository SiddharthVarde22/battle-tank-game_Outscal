using UnityEngine;
using TMPro;

public class AchievementUIBehaviour : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    string nameOfAnimation;
    int hashOfAnimation;

    [SerializeField]
    TextMeshProUGUI achievementText;

    private void Start()
    {
        animator = GetComponent<Animator>();
        hashOfAnimation = Animator.StringToHash(nameOfAnimation);

        AchievementService.Instance.bulletsShootAchivement.bulletsFiredAchievementEvent += OnAchievementTriggered;
        AchievementService.Instance.enemiesKilledAchievement.enemiesKilledAchievementEvent += OnAchievementTriggered;
        AchievementService.Instance.timeSurvivedAchievement.timeSurvivedAchievementEvent += OnAchievementTriggered;
    }

    public void OnAchievementTriggered(int number, string nameOfAchievement)
    {
        achievementText.text = nameOfAchievement + "\n" + number;
        animator.Play(hashOfAnimation);
    }

    private void OnDestroy()
    {
        AchievementService.Instance.bulletsShootAchivement.bulletsFiredAchievementEvent -= OnAchievementTriggered;
        AchievementService.Instance.enemiesKilledAchievement.enemiesKilledAchievementEvent -= OnAchievementTriggered;
        AchievementService.Instance.timeSurvivedAchievement.timeSurvivedAchievementEvent -= OnAchievementTriggered;
    }
}
