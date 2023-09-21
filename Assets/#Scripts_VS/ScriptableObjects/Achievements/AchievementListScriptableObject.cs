using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementList", menuName = "ScriptableObjects/AchievementList")]
public class AchievementListScriptableObject : ScriptableObject
{
    public string nameOfAchievement;
    public List<int> acheivements;
}
