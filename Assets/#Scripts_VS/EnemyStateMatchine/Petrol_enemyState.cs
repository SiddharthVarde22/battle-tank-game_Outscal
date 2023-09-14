
using UnityEngine;

public class Petrol_EnemyState : EnemyState
{
    private Transform player;
    private Vector3 targetPosition;
    [SerializeField]
    private float levelXlength = 40, levelZLength = 40, minimumDistanceToChasePlayer = 5;

    private float moveSpeed;
    public override void OnEnterState(EnemyTankController enemyTankController)
    {
        base.OnEnterState(enemyTankController);
        GetRandomPosition();
        player = WorldRefrenceHolder.Instance.playerTank.transform;
        moveSpeed = enemyTankController.GetMovementSpeed();
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Update()
    {
        //rotate towards target
        transform.LookAt(targetPosition);
        //move towards target
        transform.position += moveSpeed * Time.deltaTime * transform.forward;

        //if close to player go to chase
        if (CalculateDistanceFromPlayer() <= minimumDistanceToChasePlayer)
        {
            //switch to Chase state
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Chase);
        }

        if (CalculateDistanceFromTarget() <= 0.2f)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Idle);
        }
    }

    private void GetRandomPosition()
    {
        targetPosition.x = Random.Range(-levelXlength, levelXlength);
        targetPosition.y = 0;
        targetPosition.z = Random.Range(-levelZLength, levelZLength);
    }

    private float CalculateDistanceFromTarget()
    {
        return Vector3.Distance(targetPosition, transform.position);
    }

    private float CalculateDistanceFromPlayer()
    {
        return Vector3.Distance(player.position, transform.position);
    }
}
