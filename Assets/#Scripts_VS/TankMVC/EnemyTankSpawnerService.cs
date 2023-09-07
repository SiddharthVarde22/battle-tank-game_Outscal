using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawnerService : MonoBehaviour
{
    [SerializeField]
    EnemyTankScriptableObjectsList EnemyTankScriptableObjectsList;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAnRandomenemyTank();
    }

    void SpawnAnRandomenemyTank()
    {
        int random = Random.Range(0, EnemyTankScriptableObjectsList.EnemyTankList.Length);

        EnemyTankModel_VS enemyTankModel = new EnemyTankModel_VS(EnemyTankScriptableObjectsList.EnemyTankList[random]);

        EnemyTankController_VS enemyTankController = 
            new EnemyTankController_VS(enemyTankModel, EnemyTankScriptableObjectsList.EnemyTankList[random].EnemyTankView);
    }
}
