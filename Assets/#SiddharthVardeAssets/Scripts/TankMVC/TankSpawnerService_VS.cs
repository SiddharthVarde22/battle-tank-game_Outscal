using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerService_VS : MonoBehaviour
{
    [SerializeField]
    TankView_VS tankPrefab;

    // Start is called before the first frame update
    void Start()
    {
        TankModel_VS tankModel = new TankModel_VS(10f, 100);
        TankController_VS tankController = new TankController_VS(tankModel, tankPrefab);
    }
}
