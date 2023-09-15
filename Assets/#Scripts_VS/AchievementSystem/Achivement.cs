using System;
using UnityEngine;

public class Achivement
{
    public int currentValue { get; private set; }
    public int indexOfValueToAchieve { get; private set; }
    AchievementListScriptableObject achievementListScriptable;
    public int ValueToAchieve { get; private set; }

    Action<int> achievementEvent;

    public Achivement(AchievementListScriptableObject achievementList, ref Action<int> achievementRefrence)
    {
        currentValue = 0;
        indexOfValueToAchieve = 0;
        achievementListScriptable = achievementList;
        GetNewValueToAchieve();
        achievementEvent = achievementRefrence;
    }

    public void IncreaseCurrentvalue()
    {
        if(indexOfValueToAchieve >= achievementListScriptable.acheivements.Count)
        {
            return;
        }
        currentValue++;

        if(currentValue >= ValueToAchieve)
        {
            indexOfValueToAchieve++;
        }
    }

    public void GetNewValueToAchieve()
    {
        if (indexOfValueToAchieve >= achievementListScriptable.acheivements.Count)
        {
            return;
        }

        ValueToAchieve = achievementListScriptable.acheivements[indexOfValueToAchieve];
    }
}