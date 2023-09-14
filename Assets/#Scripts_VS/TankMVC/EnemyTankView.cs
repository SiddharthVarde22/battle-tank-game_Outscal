using System.Collections;
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController EnemyTankController;
    private EnemyState currentEnemyState = null;

    private Idle_EnemyState idle_EnemyState;
    private Petrol_EnemyState petrol_EnemyState;
    private Chase_EnemyState chase_EnemyState;
    private Attack_EnemyState attack_EnemyState;

    // Start is called before the first frame update
    private void Start()
    {
        //StartToWait();
        WorldRefrenceHolder.Instance.allEnemyTanks.Add(this);
        idle_EnemyState = GetComponent<Idle_EnemyState>();
        petrol_EnemyState = GetComponent<Petrol_EnemyState>();
        chase_EnemyState = GetComponent<Chase_EnemyState>();
        attack_EnemyState = GetComponent<Attack_EnemyState>();

        ChangeEnemyState(EnemyStates_Enum.Idle);
    }

    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        this.EnemyTankController = enemyTankController;
    }

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
                OnEnemyStateChanged(chase_EnemyState);
                break;
            case EnemyStates_Enum.Attack:
                OnEnemyStateChanged(attack_EnemyState);
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
