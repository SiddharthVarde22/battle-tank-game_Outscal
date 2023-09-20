
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class BulletView : MonoBehaviour
{
    private BulletController BulletController;

    public Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void SetBulletController(BulletController bulletController)
    {
        this.BulletController = bulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletController.OnCollidedWithSomething(collision);
    }
    public void Disable()
    {
        rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        gameObject.SetActive(true);
    }
}
