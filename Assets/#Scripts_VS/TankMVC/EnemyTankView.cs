using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    EnemyTankController EnemyTankController;
    EnemyState currentEnemyState = null;

    // Start is called before the first frame update
    void Start()
    {
        //StartToWait();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveEnemyTankToRandomPosition();

        if(this.currentEnemyState != null)
        {
            currentEnemyState.Tick();
        }
    }

    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        this.EnemyTankController = enemyTankController;
    }

    public void MoveEnemyTankToRandomPosition()
    {
        if (EnemyTankController.IsMoving)
        {
            EnemyTankController.MoveTowardsTarget();
        }
    }

    void SetRandomTargetForEnemyTank()
    {
        Vector3 target;
        target.x = Random.Range(-40f, 40f);
        target.y = 0;
        target.z = Random.Range(-40f, 40f);
        EnemyTankController.SetTarget(target);
    }

    public void StartToWait()
    {
        StartCoroutine(WaitForFewSeconds(Random.Range(3, 10)));
    }

    IEnumerator WaitForFewSeconds(int timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        SetRandomTargetForEnemyTank();
    }

    public void TakeDamage(float damage)
    {
        EnemyTankController.TakeDamage(damage);
    }

    public void OnEnemyStateChanged(EnemyState newEnemyState)
    {
        if(this.currentEnemyState != null)
        {
            this.currentEnemyState.OnExitState();
            this.currentEnemyState = null;
        }

        this.currentEnemyState = newEnemyState;
        this.currentEnemyState.OnEnterState();
    }
}
