using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankView TankView { get; }
    public TankModel TankModel { get; }

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        TankView.SetTankController(this);
        WorldRefrenceHolder.Instance.playerTank = TankView;
        ScoreService.Instance.ResetPlayerScore();
    }

    public void PlayerMove(float verticalInput)
    {
        TankView.transform.position +=  verticalInput * TankModel.MovementSpeed * Time.deltaTime * TankView.transform.forward;
    }

    public void PlayerRotate(float horizontalInput)
    {
        float rotation = horizontalInput * TankModel.RotationSpeed * Time.deltaTime;
        Quaternion rotationToAdd = Quaternion.Euler(0, rotation, 0);
        TankView.transform.rotation *= rotationToAdd;
    }

    public void PlayerTankShoot(Vector3 startPosition, Quaternion startRotation)
    {
        BulletSpawnService.Instance.SpawnBullet(TankModel.tankScriptableData.Damage, startPosition, startRotation);
        AchievementService.Instance.bulletsShootAchivement.OnActionPerformed();
    }

    public void TakeDamage(float damage)
    {
        TankModel.TakeDamage(damage);
        if(TankModel.Health <= 0)
        {
            DestroyEverything();
        }
    }

    private void DestroyEverything()
    {
        DestroyTanks(0.1f);
        DestroyEnvironment(0.1f);
    }

    private async void DestroyTanks(float timeDelay)
    {
        List<EnemyTankView> tanks = WorldRefrenceHolder.Instance.allEnemyTanks;
        for (int i = 0; i < tanks.Count; i++)
        {
            GameObject.Destroy(tanks[i].gameObject);
            await new WaitForSeconds(timeDelay);
        }
        WorldRefrenceHolder.Instance.allEnemyTanks.Clear();
    }

    private async void DestroyEnvironment(float timeDelay)
    {
        Transform environmentObjects = WorldRefrenceHolder.Instance.EnvironmentParent;
        int childCount = environmentObjects.childCount;
        for(int i = childCount; i > 0; i--)
        {
            GameObject.Destroy(environmentObjects.GetChild(i - 1).gameObject);
            await new WaitForSeconds(timeDelay);
        }
        LevelLoaderService.Instance.LoadNextScene();
        GameObject.Destroy(TankView.gameObject);
    }
}
