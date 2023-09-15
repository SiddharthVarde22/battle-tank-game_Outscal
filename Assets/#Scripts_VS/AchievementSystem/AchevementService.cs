
using UnityEngine;
using System;

public class AchevementService : GenericSingleton<AchevementService>
{
    public Action<int> BulletsFiredAchievementEvent;
    
    [SerializeField]
    AchievementListScriptableObject bulletsFiredAchievementScriptable;
    Achivement bulletsFiredAchievements;

    protected override void Awake()
    {
        base.Awake();
        bulletsFiredAchievements = new Achivement(bulletsFiredAchievementScriptable,ref BulletsFiredAchievementEvent);
    }

    public void OnBulletFired()
    {
        bulletsFiredAchievements.IncreaseCurrentvalue();
        if(bulletsFiredAchievements.currentValue >= bulletsFiredAchievements.ValueToAchieve)
        {
            BulletsFiredAchievementEvent?.Invoke(bulletsFiredAchievements.ValueToAchieve);
            bulletsFiredAchievements.GetNewValueToAchieve();
        }
    }
}
