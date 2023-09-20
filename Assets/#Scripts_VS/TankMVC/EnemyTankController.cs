
using UnityEngine;

public class EnemyTankController
{
    private EnemyTankModel EnemyTankModel;
    private EnemyTankView EnemyTankView;

    public bool IsMoving { get; private set; }

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
            //OnEnemyGotKilled();
            //GameObject.Destroy(EnemyTankView.gameObject);
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

    private void OnEnemyGotKilled()
    {
        AchievementService.Instance.enemiesKilledAchievement.OnActionPerformed();
        EnemyTankSpawnerService.Instance.SpawnAnRandomenemyTank();
    }

    public void Enable()
    {
        EnemyTankView.Enable();
        EnemyTankView.SetEnemyTankController(this);
        Debug.Log("Enemy tank type is " + EnemyTankModel.EnemyTankScriptableObject.TankType);
    }

    public void Disable()
    {
        AchievementService.Instance.enemiesKilledAchievement.OnActionPerformed();
        EnemyTankSpawnerService.Instance.SpawnAnRandomenemyTank();
        EnemyTankObjectPool.Instance.ReturnPooledObject(this);
        EnemyTankView.Disable();
        EnemyTankModel.ResetHealth();
    }
}
