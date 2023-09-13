using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel : CommonTankModel
{
    public EnemyTankScriptableObject EnemyTankScriptableObject { get; }

    public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
    {
        EnemyTankScriptableObject = enemyTankScriptableObject;
        Health = enemyTankScriptableObject.Health;
    }
}
