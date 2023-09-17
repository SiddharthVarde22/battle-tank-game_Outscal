using System;
using UnityEngine;

public class BulletsShootAchivement : Achivement
{
    public event Action<int> bulletsFiredAchievementEvent;

    public BulletsShootAchivement(AchievementListScriptableObject achievementList) : base(achievementList)
    {
        this.achievementListScriptable = achievementList;
        this.indexOfValueToAchieve = 0;
        this.currentValue = 0;
        GetNewValueToAchieve();
    }

    protected override void OnAchievementAchieved()
    {
        bulletsFiredAchievementEvent?.Invoke(valueToAchieve);
        indexOfValueToAchieve++;
        GetNewValueToAchieve();
    }
}
