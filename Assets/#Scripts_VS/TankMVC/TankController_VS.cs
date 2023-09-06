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
}
