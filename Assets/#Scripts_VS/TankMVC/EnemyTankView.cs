using System.Collections;
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController EnemyTankController;
    private EnemyState currentEnemyState = null;

    private Idle_EnemyState idle_EnemyState;
    private Petrol_EnemyState petrol_EnemyState;

    // Start is called before the first frame update
    private void Start()
    {
        //StartToWait();
        WorldRefrenceHolder.Instance.allEnemyTanks.Add(this);
        idle_EnemyState = GetComponent<Idle_EnemyState>();
        petrol_EnemyState = GetComponent<Petrol_EnemyState>();

        ChangeEnemyState(EnemyStates_Enum.Idle);
    }

    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        this.EnemyTankController = enemyTankController;
    }

    //public void MoveEnemyTankToRandomPosition()
    //{
    //    if (EnemyTankController.IsMoving)
    //    {
    //        EnemyTankController.MoveTowardsTarget();
    //    }
    //}

    //private void SetRandomTargetForEnemyTank()
    //{
    //    Vector3 target;
    //    target.x = Random.Range(-40f, 40f);
    //    target.y = 0;
    //    target.z = Random.Range(-40f, 40f);
    //    EnemyTankController.SetTarget(target);
    //}

    //public void StartToWait()
    //{
    //    StartCoroutine(WaitForFewSeconds(Random.Range(3, 10)));
    //}

    //private IEnumerator WaitForFewSeconds(int timeToWait)
    //{
    //    yield return new WaitForSeconds(timeToWait);
    //    SetRandomTargetForEnemyTank();
    //}

    public void TakeDamage(float damage)
    {
        EnemyTankController.TakeDamage(damage);
    }

    public void ChangeEnemyState(EnemyStates_Enum newEnemyState)
    {
        switch (newEnemyState)
        {
            case EnemyStates_Enum.Idle:
                OnEnemyStateChanged(idle_EnemyState);
                break;
            case EnemyStates_Enum.Petroling:
                OnEnemyStateChanged(petrol_EnemyState);
                break;
            case EnemyStates_Enum.Chase:
                break;
            case EnemyStates_Enum.Attack:
                break;
        }
    }

    void OnEnemyStateChanged(EnemyState newEnemyState)
    {
        if (this.currentEnemyState != null)
        {
            this.currentEnemyState.OnExitState();
            this.currentEnemyState = null;
        }

        this.currentEnemyState = newEnemyState;
        this.currentEnemyState.OnEnterState(EnemyTankController);
    }
}
