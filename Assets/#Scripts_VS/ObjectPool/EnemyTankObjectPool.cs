using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankObjectPool : GenericObjectPool<EnemyTankController>
{
    private EnemyTankModel enemyTankModel;
    private EnemyTankView enemyTankView;

    public EnemyTankController GetEnemyTank(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView)
    {
        this.enemyTankModel = enemyTankModel;
        this.enemyTankView = enemyTankView;
        return GetPooledObject();
    }

    protected override EnemyTankController CreatePoolItemInPooledObject()
    {
        EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, enemyTankView);
        return enemyTankController;
    }
}
