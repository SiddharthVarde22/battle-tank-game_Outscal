using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/EnemyTank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TypesOfTank TankType;
    public float MovementSpeed;
    public float RotationSpeed;
    public int Health;
    public float Damage;
    public EnemyTankView_VS EnemyTankView;
    public float timeToStayInIdle;
}
