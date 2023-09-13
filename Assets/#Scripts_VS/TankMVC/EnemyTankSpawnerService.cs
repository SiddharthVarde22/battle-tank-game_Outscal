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

        EnemyTankModel enemyTankModel = new EnemyTankModel(EnemyTankScriptableObjectsList.EnemyTankList[random]);

        EnemyTankController enemyTankController = 
            new EnemyTankController(enemyTankModel, EnemyTankScriptableObjectsList.EnemyTankList[random].EnemyTankView);
    }
}
