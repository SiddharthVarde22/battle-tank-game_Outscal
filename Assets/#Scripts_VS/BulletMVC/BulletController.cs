using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletModel BulletModel { get; }
    BulletView BulletView { get; }

    public BulletController(BulletModel bulletModel, BulletView bulletView)
    {
        this.BulletModel = bulletModel;
        this.BulletView = GameObject.Instantiate<BulletView>(bulletView);
        this.BulletView.SetBulletController(this);
        SetPositionAndRotaion(bulletModel.StartPosition, bulletModel.StartRotation);
        ShootTheBullet();
    }

    public void ShootTheBullet()
    {
        BulletView.GetComponent<Rigidbody>().AddForce(BulletModel.InitialForce * BulletView.transform.forward, ForceMode.Impulse);
    }

    public void SetPositionAndRotaion(Vector3 position, Quaternion rotation)
    {
        BulletView.transform.position = position;
        BulletView.transform.rotation = rotation;
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

        GameObject.Destroy(BulletView.gameObject);
    }
}
