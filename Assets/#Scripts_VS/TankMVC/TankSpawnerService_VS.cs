using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerService_VS : MonoBehaviour
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

        TankModel_VS tankModel = new TankModel_VS(tanksList.tankScriptableObjectsList[randomNumber]);

        TankController_VS tankController = new TankController_VS(tankModel, tanksList.tankScriptableObjectsList[randomNumber].TankView);
    }
}
