
using UnityEngine;
using System;

public class AchievementService : GenericSingleton<AchievementService>
{
    [SerializeField]
    AchievementListScriptableObject bulletsShootAchievementListScriptable,
        enemiesKilledAchievementListScriptable,
        timeSurvivedAchievementListScriptable;

    public BulletsShootAchivement bulletsShootAchivement;
    public EnemiesKilledAchievement enemiesKilledAchievement;
    public TimeSurvivedAchievement timeSurvivedAchievement;

    protected override void Awake()
    {
        base.Awake();
        bulletsShootAchivement = new BulletsShootAchivement(bulletsShootAchievementListScriptable);
        enemiesKilledAchievement = new EnemiesKilledAchievement(enemiesKilledAchievementListScriptable);
        timeSurvivedAchievement = new TimeSurvivedAchievement(timeSurvivedAchievementListScriptable);
    }
}
