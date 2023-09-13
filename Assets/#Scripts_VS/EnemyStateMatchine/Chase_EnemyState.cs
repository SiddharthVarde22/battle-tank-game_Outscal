using UnityEngine;

public class Chase_EnemyState : EnemyState
{
    private Transform player;
    private float moveSpeed;

    [SerializeField]
    private float distanceToNeededToShootPlayer = 3, distanceNeededToGoBackToPetrol = 7;

    public override void OnEnterState(EnemyTankController enemyTankController)
    {
        base.OnEnterState(enemyTankController);
        player = WorldRefrenceHolder.Instance.playerTank.transform;
        moveSpeed = enemyTankController.GetMovementSpeed();
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Update()
    {
        //Rotate towards player
        transform.LookAt(player);
        //move towards player
        transform.position += moveSpeed * Time.deltaTime * transform.forward;

        if(DistanceFromPlayer() <= distanceToNeededToShootPlayer)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Attack);
        }
        else if(DistanceFromPlayer() >= distanceNeededToGoBackToPetrol)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Petroling);
        }
    }

    private float DistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}
