using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    EnemyTankModel EnemyTankModel;
    EnemyTankView EnemyTankView;

    public bool IsMoving { get; private set; }

    Vector3 target = Vector3.zero;

    EnemyStates_Enum currentEnemyState = EnemyStates_Enum.Idle;

    public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView)
    {
        this.EnemyTankModel = enemyTankModel;
        this.EnemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView);
        this.EnemyTankView.SetEnemyTankController(this);
        IsMoving = false;
        ChangeEnemyState(currentEnemyState);
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

    public void ChangeEnemyState(EnemyStates_Enum newEnemyState)
    {
        EnemyState enemyState = null;

        switch(newEnemyState)
        {
            case EnemyStates_Enum.Idle:
                enemyState = new Idle_EnemyState(this, EnemyTankModel.EnemyTankScriptableObject.timeToStayInIdle);
                break;
            case EnemyStates_Enum.Petroling:
                break;
            case EnemyStates_Enum.Chase:
                break;
            case EnemyStates_Enum.Attack:
                break;
            default:
                enemyState = new Idle_EnemyState(this, EnemyTankModel.EnemyTankScriptableObject.timeToStayInIdle);
                break;
        }

        EnemyTankView.OnEnemyStateChanged(enemyState);
        currentEnemyState = newEnemyState;
    }
}
