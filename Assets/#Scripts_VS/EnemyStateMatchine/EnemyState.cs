using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyTankController EnemyTankController;
    public EnemyState(EnemyTankController enemyTankController)
    {
        this.EnemyTankController = enemyTankController;
    }
    public abstract void OnEnterState();
    public abstract void OnExitState();
    public abstract void Tick();
}
