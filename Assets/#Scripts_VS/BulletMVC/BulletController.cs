
using UnityEngine;

public class BulletController
{
    private BulletModel BulletModel { get; }
    private BulletView BulletView { get; }

    public BulletController(BulletModel bulletModel, BulletView bulletView)
    {
        this.BulletModel = bulletModel;
        this.BulletView = GameObject.Instantiate<BulletView>(bulletView);
        this.BulletView.SetBulletController(this);
    }

    public void ShootTheBullet()
    {
        BulletView.rigidbody.AddForce(BulletModel.InitialForce * BulletView.transform.forward, ForceMode.Impulse);
    }

    public void SetPositionAndRotaion(Vector3 position, Quaternion rotation)
    {
        BulletView.transform.SetPositionAndRotation(position, rotation);
    }

    public void OnCollidedWithSomething(Collision collision)
    {
        TankView playerTank;
        EnemyTankView enemytank;

        if(collision.transform.TryGetComponent<TankView>(out playerTank))
        {
            playerTank.TakeDamage(BulletModel.Damage);
        }
        else if(collision.transform.TryGetComponent<EnemyTankView>(out enemytank))
        {
            enemytank.TakeDamage(BulletModel.Damage);
        }

        Disable();
    }

    public void Enable(float initialForce, float damage,Vector3 startPosition, Quaternion startRotation)
    {
        BulletModel.SetProperties(initialForce, damage, startPosition, startRotation);
        SetPositionAndRotaion(BulletModel.StartPosition, BulletModel.StartRotation);
        BulletView.Enable();
        ShootTheBullet();
    }

    public void Disable()
    {
        BulletView.Disable();
        BulletObjectPool.Instance.ReturnPooledObject(this);
    }
}
