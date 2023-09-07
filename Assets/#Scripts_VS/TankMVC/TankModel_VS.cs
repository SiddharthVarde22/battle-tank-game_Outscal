using UnityEngine;

public class TankModel_VS
{
    public TankScriptableObject tankScriptableData { get; }
    public float MovementSpeed {get;}
    public float RotationSpeed { get; }
    public int Health { get; private set; }

    public TankModel_VS(float movementSpeed, int health)
    {
        MovementSpeed = movementSpeed;
        Health = health;
    }

    public TankModel_VS(TankScriptableObject tankScriptableObject)
    {
        tankScriptableData = tankScriptableObject;
        MovementSpeed = tankScriptableObject.MovementSpeed;
        RotationSpeed = tankScriptableObject.RotationSpeed;
        Health = tankScriptableObject.Health;

        //Debug.Log("Tank speed " + MovementSpeed + " health " + Health);
        Debug.Log("Player tank type " + tankScriptableObject.TankType);
    }

    public void TakeDamage(float damage)
    {
        Health -= (int)damage;
    }
}
