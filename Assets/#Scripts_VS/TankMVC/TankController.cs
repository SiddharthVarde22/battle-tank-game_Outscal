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

        AchievementService.Instance.bulletsShootAchivement.bulletsFiredAchievementEvent += OnBulletsShootEventTriggered;
        AchievementService.Instance.enemiesKilledAchievement.enemiesKilledAchievementEvent += OnEnemiesKilledEventTriggered;
        AchievementService.Instance.timeSurvivedAchievement.timeSurvivedAchievementEvent += OnTimeSurvivedEventTriggered;
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

    public void OnBulletsShootEventTriggered(int numberOfbulletsShooted)
    {
        //I will add apropiate functionalities later
        // right now i have just created an observer system
        Debug.Log("Player shooted " + numberOfbulletsShooted + " bullets");
    }

    public void OnEnemiesKilledEventTriggered(int numberOfKilledEnemies)
    {
        //I will add apropiate functionalities later
        // right now i have just created an observer system
        Debug.Log("Player Killed " + numberOfKilledEnemies + " Enemies");
    }

    public void OnTimeSurvivedEventTriggered(int timeSurvived)
    {
        //I will add apropiate functionalities later
        // right now i have just created an observer system
        Debug.Log("Player Survived " + timeSurvived + " Seconds");
    }

    public void TakeDamage(float damage)
    {
        TankModel.TakeDamage(damage);
        if(TankModel.Health <= 0)
        {
            DestroyEverything();
            GameObject.Destroy(TankView.gameObject);
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
    }

    ~TankController()
    {
        AchievementService.Instance.bulletsShootAchivement.bulletsFiredAchievementEvent -= OnBulletsShootEventTriggered;
        AchievementService.Instance.enemiesKilledAchievement.enemiesKilledAchievementEvent -= OnEnemiesKilledEventTriggered;
        AchievementService.Instance.timeSurvivedAchievement.timeSurvivedAchievementEvent -= OnTimeSurvivedEventTriggered;
    }
}
