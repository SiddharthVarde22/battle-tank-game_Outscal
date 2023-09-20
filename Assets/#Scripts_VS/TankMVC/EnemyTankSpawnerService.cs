
using UnityEngine;

public class EnemyTankSpawnerService : GenericSingleton<EnemyTankSpawnerService>
{
    [SerializeField]
    private EnemyTankScriptableObjectsList EnemyTankScriptableObjectsList;
    [SerializeField]
    private EnemyTankObjectPool enemyTankObjectPool;

    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            SpawnAnRandomenemyTank();
        }
    }

    public void SpawnAnRandomenemyTank()
    {
        int random = Random.Range(0, EnemyTankScriptableObjectsList.EnemyTankList.Length);

        EnemyTankModel enemyTankModel = new EnemyTankModel(EnemyTankScriptableObjectsList.EnemyTankList[random]);

        EnemyTankController enemyTankController =
            enemyTankObjectPool.GetEnemyTank(enemyTankModel, EnemyTankScriptableObjectsList.EnemyTankList[random].EnemyTankView);
        enemyTankController.Enable();
    }
}
