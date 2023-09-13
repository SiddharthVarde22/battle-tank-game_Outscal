using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerService : MonoBehaviour
{
    //[SerializeField]
    //TankView_VS tankPrefab;
    [SerializeField]
    TanksListScriptableObject tanksList;

    // Start is called before the first frame update
    void Start()
    {
        SpawnARandomPlayerTank();
    }

    void SpawnARandomPlayerTank()
    {
        int randomNumber = Random.Range(0, tanksList.tankScriptableObjectsList.Length);

        TankModel tankModel = new TankModel(tanksList.tankScriptableObjectsList[randomNumber]);

        TankController tankController = new TankController(tankModel, tanksList.tankScriptableObjectsList[randomNumber].TankView);
    }
}
