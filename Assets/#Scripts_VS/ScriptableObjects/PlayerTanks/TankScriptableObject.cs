using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypesOfTank
{
    None,
    Red,
    Blue,
    Green
};

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankObject")]
public class TankScriptableObject : ScriptableObject
{
    public TypesOfTank TankType;
    public float MovementSpeed;
    public float RotationSpeed;
    public int Health;
    public float Damage;
    public TankView TankView;
}
