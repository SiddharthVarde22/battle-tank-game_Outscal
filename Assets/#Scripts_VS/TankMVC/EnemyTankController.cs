
using UnityEngine;

public class EnemyTankController
{
    private EnemyTankModel EnemyTankModel;
    private EnemyTankView EnemyTankView;

    public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView)
    {
        this.EnemyTankModel = enemyTankModel;
        this.EnemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView);
        this.EnemyTankView.SetEnemyTankController(this);
    }

    public void TakeDamage(float damage)
    {
        EnemyTankModel.TakeDamage(damage);

        if(EnemyTankModel.Health <= 0)
        {
            Disable();
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

    public void Enable()
    {
        EnemyTankView.Enable();
        EnemyTankView.SetEnemyTankController(this);
    }

    public void Disable()
    {
        AchievementService.Instance.enemiesKilledAchievement.OnActionPerformed();
        ScoreService.Instance.IncreasePlayerScore(1);
        EnemyTankSpawnerService.Instance.SpawnAnRandomenemyTank();
        EnemyTankObjectPool.Instance.ReturnPooledObject(this);
        EnemyTankView.Disable();
        EnemyTankModel.ResetHealth();
    }
}
