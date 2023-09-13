using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class BulletView : MonoBehaviour
{
    BulletController BulletController;

    Rigidbody rigidbody;

    public void SetBulletController(BulletController bulletController)
    {
        this.BulletController = bulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletController.OnCollidedWithSomething(collision);
    }
}
