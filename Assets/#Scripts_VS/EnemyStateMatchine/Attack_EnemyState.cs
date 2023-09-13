
using UnityEngine;

public class Attack_EnemyState : EnemyState
{
    private Transform player;

    [SerializeField]
    private float shootRate = 10, distanceToStartChasing = 5;

    private float timeToWaitBeforeShoot;
    private float currentTime;

    [SerializeField]
    private Transform shootPointTransform;

    public override void OnEnterState(EnemyTankController enemyTankController)
    {
        base.OnEnterState(enemyTankController);
        player = WorldRefrenceHolder.Instance.playerTank.transform;
        currentTime = 0;
        timeToWaitBeforeShoot = 60 / shootRate;
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Update()
    {
        // rotate towards player
        transform.LookAt(player);

        currentTime += Time.deltaTime;

        if(currentTime >= timeToWaitBeforeShoot)
        {
            ShootBullet();
        }

        if(DistanceFromPlayer() >= distanceToStartChasing)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Chase);
        }
    }

    private float DistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }

    private void ShootBullet()
    {
        EnemyTankController.Shoot(shootPointTransform);
        currentTime = 0;
    }
}
