using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_EnemyState : EnemyState_VS
{
    float TimeToWait;
    float currentTime;
    public Idle_EnemyState(EnemyTankController_VS enemyTankController, float timeToWait) : base(enemyTankController)
    {
        this.TimeToWait = timeToWait;
        currentTime = 0;
    }
    public override void OnEnterState()
    {
        Debug.Log("On Idle start");
    }
    public override void OnExitState()
    {
        Debug.Log("on idle Stop");
    }

    public override void Tick()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= TimeToWait)
        {
            //controller.changestate
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Petroling);
        }
    }
}
