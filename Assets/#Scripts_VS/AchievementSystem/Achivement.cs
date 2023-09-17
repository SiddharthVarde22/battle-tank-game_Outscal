using System;
using UnityEngine;

public abstract class Achivement
{
    protected int currentValue;
    protected int valueToAchieve;
    protected int indexOfValueToAchieve;
    protected AchievementListScriptableObject achievementListScriptable;

    public Achivement(AchievementListScriptableObject achievementList)
    {
        achievementListScriptable = achievementList;
        currentValue = 0;
        indexOfValueToAchieve = 0;
        GetNewValueToAchieve();
    }

    public virtual void OnActionPerformed()
    {
        if (CheckIfAllAchievementsAreAchieved())
        {
            return;
        }
        currentValue++;
        if (CheckIfCurrentAchievementIsAchieved())
        {
            OnAchievementAchieved();
        }
    }

    public virtual void OnActionPerfomed(int value)
    {
        if (CheckIfAllAchievementsAreAchieved())
        {
            return;
        }
        currentValue += value;
        if (CheckIfCurrentAchievementIsAchieved())
        {
            OnAchievementAchieved();
        }
    }
    protected abstract void OnAchievementAchieved();

    protected virtual bool CheckIfAllAchievementsAreAchieved()
    {
        return indexOfValueToAchieve >= this.achievementListScriptable.acheivements.Count;
    }

    protected virtual bool CheckIfCurrentAchievementIsAchieved()
    {
        return currentValue >= valueToAchieve;
    }

    protected virtual void GetNewValueToAchieve()
    {
        if (CheckIfAllAchievementsAreAchieved())
        {
            return;
        }
        valueToAchieve = achievementListScriptable.acheivements[indexOfValueToAchieve];
    }
}