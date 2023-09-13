
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class BulletView : MonoBehaviour
{
    private BulletController BulletController;

    private Rigidbody rigidbody;

    public void SetBulletController(BulletController bulletController)
    {
        this.BulletController = bulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletController.OnCollidedWithSomething(collision);
    }
}
