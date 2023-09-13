
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/EnemyTank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TypesOfTank TankType;
    public float MovementSpeed;
    public float RotationSpeed;
    public int Health;
    public float Damage;
    public EnemyTankView EnemyTankView;
    public float timeToStayInIdle;
}
