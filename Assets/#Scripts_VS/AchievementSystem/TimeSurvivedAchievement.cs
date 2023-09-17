using System;
using UnityEngine;

public class TimeSurvivedAchievement : Achivement
{
    public event Action<int> timeSurvivedAchievementEvent;

    public TimeSurvivedAchievement(AchievementListScriptableObject achievementList) : base(achievementList)
    {
        this.achievementListScriptable = achievementList;
        this.currentValue = 0;
        this.indexOfValueToAchieve = 0;
        GetNewValueToAchieve();
    }

    protected override void OnAchievementAchieved()
    {
        timeSurvivedAchievementEvent?.Invoke(valueToAchieve);
        indexOfValueToAchieve++;
        GetNewValueToAchieve();
    }
}
