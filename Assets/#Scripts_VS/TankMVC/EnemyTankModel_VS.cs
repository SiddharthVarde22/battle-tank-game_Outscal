using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel_VS
{
    public EnemyTankScriptableObject EnemyTankScriptableObject { get; }
    public EnemyTankModel_VS(EnemyTankScriptableObject enemyTankScriptableObject)
    {
        EnemyTankScriptableObject = enemyTankScriptableObject;
        Debug.Log("Enemy tank type " + enemyTankScriptableObject.TankType);
    }
}
