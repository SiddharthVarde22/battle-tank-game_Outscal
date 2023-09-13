
using UnityEngine;

public class Petrol_enemyState : EnemyState
{
    private Transform player, myTransform;
    private Vector3 targetPosition;
    private float levelXlength, levelZLength;
    private float distanceFromPlayerToShoot;

    public Petrol_enemyState(EnemyTankController enemyTankController, Transform player, 
        float Xlength, float Zlength):base(enemyTankController)
    {
        this.player = player;
        this.levelXlength = Xlength;
        this.levelZLength = Zlength;
    }
    public override void OnEnterState()
    {
        GetRandomPosition();
    }
    public override void OnExitState()
    {

    }
    public override void Tick()
    {
        if(CalculateDistanceFromTarget() <= 0.2f)
        {
            EnemyTankController.ChangeEnemyState(EnemyStates_Enum.Idle);
        }

        //rotate towards target
        //move towards target

        //if close to player go to chase
    }

    private void GetRandomPosition()
    {
        targetPosition.x = Random.Range(-levelXlength, levelXlength);
        targetPosition.y = 0;
        targetPosition.z = Random.Range(-levelZLength, levelZLength);
    }

    private float CalculateDistanceFromTarget()
    {
        return Vector3.Distance(targetPosition, myTransform.position);
    }
}
