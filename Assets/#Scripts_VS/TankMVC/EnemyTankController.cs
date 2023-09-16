
using UnityEngine;

public class EnemyTankController
{
    private EnemyTankModel EnemyTankModel;
    private EnemyTankView EnemyTankView;

    public bool IsMoving { get; private set; }

    //private Vector3 target = Vector3.zero;

    public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView)
    {
        this.EnemyTankModel = enemyTankModel;
        this.EnemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView);
        this.EnemyTankView.SetEnemyTankController(this);
        IsMoving = false;
    }

    public void TakeDamage(float damage)
    {
        EnemyTankModel.TakeDamage(damage);

        if(EnemyTankModel.Health <= 0)
        {
            GameObject.Destroy(EnemyTankView.gameObject);
        }
    }

    public void ChangeEnemyState(EnemyStates_Enum newEnemyState_Enum)
    {
        EnemyTankView.ChangeEnemyState(newEnemyState_Enum);
    }

    public float GetMovementSpeed()
    {
        return EnemyTankModel.EnemyTankScriptableObject.MovementSpeed;
    }

    public void Shoot(Transform shootPoint)
    {
        BulletSpawnService.Instance.SpawnBullet(EnemyTankModel.EnemyTankScriptableObject.Damage,shootPoint.position, shootPoint.rotation);
    }

    void OnEnemyGotKilled()
    {
        AchievementService.Instance.OnEnemyKilled();
        EnemyTankSpawnerService.Instance.SpawnAnRandomenemyTank();
    }

    ~EnemyTankController()
    {
        Debug.Log("Enemy tank controller destructor");
        OnEnemyGotKilled();
    }
}
