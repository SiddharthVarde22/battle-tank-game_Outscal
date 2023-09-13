using UnityEngine;

public class TankModel : CommonTankModel
{
    public TankScriptableObject tankScriptableData { get; }
    public float MovementSpeed {get;}
    public float RotationSpeed { get; }

    public TankModel(float movementSpeed, int health)
    {
        MovementSpeed = movementSpeed;
        Health = health;
    }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        tankScriptableData = tankScriptableObject;
        MovementSpeed = tankScriptableObject.MovementSpeed;
        RotationSpeed = tankScriptableObject.RotationSpeed;
        Health = tankScriptableObject.Health;
    }
}
