using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnService : GenericSingleton_VS<BulletSpawnService>
{
    [SerializeField]
    BulletScriptableObject BulletScriptableObject;
    public void SpawnBullet(float damage, Vector3 startPosition, Quaternion startRotation)
    {
        BulletModel_VS bulletModel = new BulletModel_VS(BulletScriptableObject.InitialForce, damage, startPosition, startRotation);
        BulletController_VS bulletController = new BulletController_VS(bulletModel, BulletScriptableObject.BulletView);
    }
}
