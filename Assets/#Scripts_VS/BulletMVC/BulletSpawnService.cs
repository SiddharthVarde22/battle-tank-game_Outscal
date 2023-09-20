
using UnityEngine;

public class BulletSpawnService : GenericSingleton<BulletSpawnService>
{
    [SerializeField]
    private BulletScriptableObject BulletScriptableObject;
    [SerializeField]
    BulletObjectPool BulletObjectPool;
    public void SpawnBullet(float damage, Vector3 startPosition, Quaternion startRotation)
    {
        BulletModel bulletModel = new BulletModel(BulletScriptableObject.InitialForce, damage, startPosition, startRotation);
        //BulletController bulletController = new BulletController(bulletModel, BulletScriptableObject.BulletView);
        BulletController bulletController = BulletObjectPool.GetBullet(bulletModel, BulletScriptableObject.BulletView);
        bulletController.Enable(BulletScriptableObject.InitialForce, damage, startPosition, startRotation);
    }
}
