
using UnityEngine;

public class BulletModel
{
    public float InitialForce { get; private set; }
    public float Damage { get; private set; }
    public Vector3 StartPosition { get; private set; }
    public Quaternion StartRotation { get; private set; }
    public BulletModel(float initialForce ,float damage, Vector3 startPosition, Quaternion startRotaion)
    {
        SetProperties(initialForce, damage, startPosition, startRotaion);
    }

    public void SetProperties(float initialForce, float damage, Vector3 startPosition, Quaternion startRotaion)
    {
        this.InitialForce = initialForce;
        this.Damage = damage;
        this.StartPosition = startPosition;
        this.StartRotation = startRotaion;
    }
}
