using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController_VS
{
    BulletModel_VS BulletModel { get; }
    BulletView_VS BulletView { get; }

    public BulletController_VS(BulletModel_VS bulletModel, BulletView_VS bulletView)
    {
        this.BulletModel = bulletModel;
        this.BulletView = GameObject.Instantiate<BulletView_VS>(bulletView);
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
        TankView_VS playerTank;
        EnemyTankView_VS enemytank;

        if(collision.transform.TryGetComponent<TankView_VS>(out playerTank))
        {
            Debug.Log("Collided with player");
            playerTank.TakeDamage(BulletModel.Damage);
        }
        else if(collision.transform.TryGetComponent<EnemyTankView_VS>(out enemytank))
        {
            Debug.Log("collided with Enemy Tank");
            enemytank.TakeDamage(BulletModel.Damage);
        }

        GameObject.Destroy(BulletView.gameObject);
    }
}
