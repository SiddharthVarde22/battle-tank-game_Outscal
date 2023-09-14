
using UnityEngine;
public class EnemyState : MonoBehaviour
{
    protected EnemyTankController EnemyTankController;
    public virtual void OnEnterState(EnemyTankController enemyTankController)
    {
        this.enabled = true;
        this.EnemyTankController = enemyTankController;
    }
    public virtual void OnExitState()
    {
        this.enabled = false;
    }
}
