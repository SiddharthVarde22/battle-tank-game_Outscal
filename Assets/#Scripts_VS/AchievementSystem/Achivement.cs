using System;
using UnityEngine;

public class Achivement
{
    public int currentValue { get; private set; }
    public int indexOfValueToAchieve { get; private set; }
    AchievementListScriptableObject achievementListScriptable;
    public int ValueToAchieve { get; private set; }

    Action<int> achievementEventCallback;

    public Achivement(AchievementListScriptableObject achievementList, Action<int> achievementEventCallback)
    {
        currentValue = 0;
        indexOfValueToAchieve = 0;
        achievementListScriptable = achievementList;
        GetNewValueToAchieve();
        this.achievementEventCallback = achievementEventCallback;
    }

    public void IncreaseCurrentValue()
    {
        if(CheckIfOutOfBound())
        {
            return;
        }
        currentValue++;

        CheckIfAchievementIsAchieved();
    }

    public void IncreaseCurrentValue(int valueToIncrease)
    {
        if(CheckIfOutOfBound())
        {
            return;
        }
        currentValue += valueToIncrease;
        CheckIfAchievementIsAchieved();
    }

    public void GetNewValueToAchieve()
    {
        if (CheckIfOutOfBound())
        {
            return;
        }

        ValueToAchieve = achievementListScriptable.acheivements[indexOfValueToAchieve];
    }

    bool CheckIfOutOfBound()
    {
        return indexOfValueToAchieve >= achievementListScriptable.acheivements.Count;
    }

    void CheckIfAchievementIsAchieved()
    {
        if (currentValue >= ValueToAchieve)
        {
            achievementEventCallback?.Invoke(ValueToAchieve);
            indexOfValueToAchieve++;
            GetNewValueToAchieve();
        }
    }
}