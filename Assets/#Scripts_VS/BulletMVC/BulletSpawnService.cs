
using UnityEngine;

public class BulletSpawnService : GenericSingleton<BulletSpawnService>
{
    [SerializeField]
    private BulletScriptableObject BulletScriptableObject;
    public void SpawnBullet(float damage, Vector3 startPosition, Quaternion startRotation)
    {
        BulletModel bulletModel = new BulletModel(BulletScriptableObject.InitialForce, damage, startPosition, startRotation);
        BulletController bulletController = new BulletController(bulletModel, BulletScriptableObject.BulletView);
    }
}
