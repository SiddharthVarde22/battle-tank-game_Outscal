using System;
using UnityEngine;

public class EnemiesKilledAchievement : Achivement
{
    public event Action<int> enemiesKilledAchievementEvent;

    public EnemiesKilledAchievement(AchievementListScriptableObject achievementList) : base(achievementList)
    {
        this.achievementListScriptable = achievementList;
        this.currentValue = 0;
        this.indexOfValueToAchieve = 0;
        GetNewValueToAchieve();
    }

    protected override void OnAchievementAchieved()
    {
        enemiesKilledAchievementEvent?.Invoke(valueToAchieve);
        indexOfValueToAchieve++;
        GetNewValueToAchieve();
    }
}
