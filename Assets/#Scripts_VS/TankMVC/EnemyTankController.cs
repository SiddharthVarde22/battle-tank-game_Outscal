
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

    //public void MoveTowardsTarget()
    //{
    //    EnemyTankView.transform.position += 
    //        EnemyTankModel.EnemyTankScriptableObject.MovementSpeed * Time.deltaTime * EnemyTankView.transform.forward;

    //    EnemyTankView.transform.LookAt(target);

    //    if((EnemyTankView.transform.position - target).magnitude <= 0.5f)
    //    {
    //        IsMoving = false;
    //        EnemyTankView.StartToWait();
    //    }
    //}

    //public void SetTarget(Vector3 target)
    //{
    //    this.target = target;
    //    IsMoving = true;
    //}

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
}
