using UnityEngine;

public class TankModel_VS
{
    public float MovementSpeed {get;}
    public int Health { get; }

    public TankModel_VS(float movementSpeed, int health)
    {
        MovementSpeed = movementSpeed;
        Health = health;
    }
}
