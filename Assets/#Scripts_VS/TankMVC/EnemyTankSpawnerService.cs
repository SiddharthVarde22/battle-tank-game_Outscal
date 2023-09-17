
using UnityEngine;

public class EnemyTankSpawnerService : GenericSingleton<EnemyTankSpawnerService>
{
    [SerializeField]
    private EnemyTankScriptableObjectsList EnemyTankScriptableObjectsList;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnAnRandomenemyTank();
    }

    public void SpawnAnRandomenemyTank()
    {
        int random = Random.Range(0, EnemyTankScriptableObjectsList.EnemyTankList.Length);

        EnemyTankModel enemyTankModel = new EnemyTankModel(EnemyTankScriptableObjectsList.EnemyTankList[random]);

        EnemyTankController enemyTankController = 
            new EnemyTankController(enemyTankModel, EnemyTankScriptableObjectsList.EnemyTankList[random].EnemyTankView);
    }
}
