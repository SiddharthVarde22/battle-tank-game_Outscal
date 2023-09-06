using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObjectsList", menuName = "ScriptableObjects/EnemyTankList")]
public class EnemyTankScriptableObjectsList : ScriptableObject
{
    public EnemyTankScriptableObject[] EnemyTankList;
}
