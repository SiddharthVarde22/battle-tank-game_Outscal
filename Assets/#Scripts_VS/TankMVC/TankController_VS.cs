using UnityEngine;

public class TankController_VS
{
    public TankView_VS TankView { get; }
    public TankModel_VS TankModel { get; }

    public TankController_VS(TankModel_VS tankModel, TankView_VS tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView_VS>(tankPrefab);
        TankView.SetTankController(this);
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

    void DestroyEverything()
    {
        DestroyTanks(0.1f);
        DestroyEnvironment(0.1f);
    }

    async void DestroyTanks(float timeDelay)
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
        for (int i = 0; i < tanks.Length; i++)
        {
            GameObject.Destroy(tanks[i]);
            await new WaitForSeconds(timeDelay);
        }
    }

    async void DestroyEnvironment(float timeDelay)
    {
        GameObject[] environmentObjects = GameObject.FindGameObjectsWithTag("Environment");

        for(int i = 0; i < environmentObjects.Length; i++)
        {
            GameObject.Destroy(environmentObjects[i]);
            await new WaitForSeconds(timeDelay);
        }
    }
}
