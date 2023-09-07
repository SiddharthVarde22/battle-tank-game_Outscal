using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class BulletView_VS : MonoBehaviour
{
    BulletController_VS BulletController;

    Rigidbody rigidbody;

    public void SetBulletController(BulletController_VS bulletController)
    {
        this.BulletController = bulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletController.OnCollidedWithSomething(collision);
    }
}
