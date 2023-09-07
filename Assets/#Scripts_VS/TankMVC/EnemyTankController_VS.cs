using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController_VS
{
    EnemyTankModel_VS EnemyTankModel;
    EnemyTankView_VS EnemyTankView;

    public bool IsMoving { get; private set; }

    Vector3 target = Vector3.zero;

    public EnemyTankController_VS(EnemyTankModel_VS enemyTankModel, EnemyTankView_VS enemyTankView)
    {
        this.EnemyTankModel = enemyTankModel;
        this.EnemyTankView = GameObject.Instantiate<EnemyTankView_VS>(enemyTankView);
        this.EnemyTankView.SetEnemyTankController(this);
        IsMoving = false;
    }

    public void MoveTowardsTarget()
    {
        EnemyTankView.transform.position += 
            EnemyTankModel.EnemyTankScriptableObject.MovementSpeed * Time.deltaTime * EnemyTankView.transform.forward;

        EnemyTankView.transform.LookAt(target);

        if((EnemyTankView.transform.position - target).magnitude <= 0.5f)
        {
            IsMoving = false;
            EnemyTankView.StartToWait();
        }
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
        IsMoving = true;
    }

    public void TakeDamage(float damage)
    {
        EnemyTankModel.TakeDamage(damage);

        if(EnemyTankModel.Health <= 0)
        {
            GameObject.Destroy(EnemyTankView.gameObject);
        }
    }
}
