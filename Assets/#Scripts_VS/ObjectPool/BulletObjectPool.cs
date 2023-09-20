using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : GenericObjectPool<BulletController>
{
    BulletModel bulletModel;
    BulletView bulletView;
    public BulletController GetBullet(BulletModel bulletModel, BulletView bulletView)
    {
        this.bulletModel = bulletModel;
        this.bulletView = bulletView;
        return GetPooledObject();
    }
    protected override BulletController CreatePoolItemInPooledObject()
    {
        BulletController bulletControllerForPool = new BulletController(bulletModel, bulletView);
        return bulletControllerForPool;
    }
}
