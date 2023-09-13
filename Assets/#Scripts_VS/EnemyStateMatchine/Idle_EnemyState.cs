
using UnityEngine;

public class Idle_EnemyState : EnemyState
{
    private float TimeToWait;
    private float currentTime;
    public Idle_EnemyState(EnemyTankController enemyTankController, float timeToWait) : base(enemyTankController)
    {
        this.TimeToWait = timeToWait;
        currentTime = 0;
    }
    public override void OnEnterState()
    {
    }
    public override void OnExitState()
    {
    }

    public override void Tick()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= TimeToWait)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Petroling);
        }
    }
}
