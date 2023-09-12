using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState_VS
{
    protected EnemyTankController_VS EnemyTankController;
    public EnemyState_VS(EnemyTankController_VS enemyTankController)
    {
        this.EnemyTankController = enemyTankController;
    }
    public abstract void OnEnterState();
    public abstract void OnExitState();
    public abstract void Tick();
}
