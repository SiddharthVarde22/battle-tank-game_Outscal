using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float InitialForce { get; }
    public float Damage { get; }
    public Vector3 StartPosition { get; }
    public Quaternion StartRotation { get; }
    public BulletModel(float initialForce ,float damage, Vector3 startPosition, Quaternion startRotaion)
    {
        this.InitialForce = initialForce;
        this.Damage = damage;
        this.StartPosition = startPosition;
        this.StartRotation = startRotaion;
    }
}
