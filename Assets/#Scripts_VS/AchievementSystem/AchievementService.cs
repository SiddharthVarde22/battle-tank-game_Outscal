
using UnityEngine;
using System;

public class AchievementService : GenericSingleton<AchievementService>
{
    public Action<int> BulletsFiredAchievementEvent;
    
    [SerializeField]
    AchievementListScriptableObject bulletsFiredAchievementScriptable;
    Achivement bulletsFiredAchievements;

    protected override void Awake()
    {
        base.Awake();
        bulletsFiredAchievements = new Achivement(bulletsFiredAchievementScriptable, OnBulletFiredAchievementReached);
        enemiesKilledAchievement = new Achivement(enemiesKilledAchievementScriptable, OnEnemiesKilledAchievementReached);
        timeSurvivedAchievement = new Achivement(timeSurvivedAchievementScriptable, OnTimeSurvivedAchievementReached);
    }

    public void OnBulletFired()
    {
        bulletsFiredAchievements.IncreaseCurrentValue();
    }

    public void OnBulletFiredAchievementReached(int bulletsFired)
    {
        BulletsFiredAchievementEvent?.Invoke(bulletsFired);
    }

    public Action<int> OnEnemiesKilledAchievementEvent;

    [SerializeField]
    AchievementListScriptableObject enemiesKilledAchievementScriptable;
    Achivement enemiesKilledAchievement;

    public void OnEnemyKilled()
    {
        enemiesKilledAchievement.IncreaseCurrentValue();
    }

    public void OnEnemiesKilledAchievementReached(int numberOfenemiesKilled)
    {
        OnEnemiesKilledAchievementEvent?.Invoke(numberOfenemiesKilled);
    }

    public Action<int> OnTimeSurvivedAchievementEvent;

    [SerializeField]
    AchievementListScriptableObject timeSurvivedAchievementScriptable;
    Achivement timeSurvivedAchievement;

    public void OnCretainTimeSurvived(int timeToAdd)
    {
        timeSurvivedAchievement.IncreaseCurrentValue(timeToAdd);
    }

    public void OnTimeSurvivedAchievementReached(int timeSurvived)
    {
        OnTimeSurvivedAchievementEvent?.Invoke(timeSurvived);
    }
}
