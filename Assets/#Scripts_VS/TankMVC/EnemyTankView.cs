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

    [SerializeField]
    float maxXPosition = 20, minXPosition = -20, maxZPosition = 20, minZPosition = -20; 

    // Start is called before the first frame update
    private void Start()
    {
        WorldRefrenceHolder.Instance.allEnemyTanks.Add(this);
        FindRefrencesOfStates();
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

    //private void OnDestroy()
    //{
    //    WorldRefrenceHolder.Instance.allEnemyTanks.Remove(this);
    //}

    public void Enable()
    {
        FindRefrencesOfStates();
        ResetPositionAndRotation();
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        ChangeEnemyState(EnemyStates_Enum.Idle);
        gameObject.SetActive(false);
    }

    void FindRefrencesOfStates()
    {
        idle_EnemyState = GetComponent<Idle_EnemyState>();
        petrol_EnemyState = GetComponent<Petrol_EnemyState>();
        chase_EnemyState = GetComponent<Chase_EnemyState>();
        attack_EnemyState = GetComponent<Attack_EnemyState>();
    }

    void ResetPositionAndRotation()
    {
        transform.SetPositionAndRotation(new Vector3(Random.Range(minXPosition, maxXPosition), 0,
            Random.Range(minZPosition, maxZPosition)), Quaternion.identity);
    }
}
