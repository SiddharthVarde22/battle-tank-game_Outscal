
using UnityEngine;

public class Petrol_EnemyState : EnemyState
{
    private Transform player;
    private Vector3 targetPosition;
    [SerializeField]
    private float levelXlength, levelZLength, minimumDistanceToChasePlayer;

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
        if (CalculateDistanceFromTarget() <= 0.2f)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Idle);
        }

        //rotate towards target
        transform.LookAt(targetPosition);
        //move towards target
        transform.position += moveSpeed * Time.deltaTime * transform.forward;

        //if close to player go to chase
        if (CalculateDistanceFromPlayer() <= minimumDistanceToChasePlayer)
        {
            //switch to Chase state
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
