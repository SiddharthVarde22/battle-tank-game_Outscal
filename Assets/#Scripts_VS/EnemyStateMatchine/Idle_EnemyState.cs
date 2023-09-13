
using UnityEngine;

public class Idle_EnemyState : EnemyState
{
    [SerializeField]
    private float TimeToWait;

    private float currentTime;
    public override void OnEnterState(EnemyTankController enemyTankController)
    {
        base.OnEnterState(enemyTankController);
        currentTime = 0;
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }

    public void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= TimeToWait)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Petroling);
        }
    }
}
