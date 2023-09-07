using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel_VS
{
    public EnemyTankScriptableObject EnemyTankScriptableObject { get; }

    public int Health { get; private set; }
    public EnemyTankModel_VS(EnemyTankScriptableObject enemyTankScriptableObject)
    {
        EnemyTankScriptableObject = enemyTankScriptableObject;
        Health = enemyTankScriptableObject.Health;
        Debug.Log("Enemy tank type " + enemyTankScriptableObject.TankType);
    }

    public void TakeDamage(float damage)
    {
        Health -= (int)damage;
    }
}
