using UnityEngine;

public class TankController_VS
{
    public TankView_VS TankView { get; }
    public TankModel_VS TankModel { get; }

    public TankController_VS(TankModel_VS tankModel, TankView_VS tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView_VS>(tankPrefab);
    }
}
