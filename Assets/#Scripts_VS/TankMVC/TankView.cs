
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankController tankController;

    private float horizontalInput, verticalInput;

    [SerializeField]
    private Transform bulletSpawnPoint;

    float currentSurvivedTime;
    [SerializeField]
    float timeDurationToUpdateSurvivedTime = 5;

    // Update is called once per frame
    private void Update()
    {
        TakeUserInput();
        TakeFireInput();
        SendCalculatedTime();
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    private void TakeUserInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput != 0)
        {
            // A/D or RightArrow/LeftArrow to rotate
            CallPlayerRotate();
        }

        if(verticalInput != 0)
        {
            // W/S or UpArrow/DownArrow to move
            CallPlayerMove();
        }
    }

    private void TakeFireInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            OnShootPressed();
        }
    }

    private void OnShootPressed()
    {
        tankController.PlayerTankShoot(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    private void CallPlayerMove()
    {
        tankController.PlayerMove(verticalInput);
    }

    private void CallPlayerRotate()
    {
        tankController.PlayerRotate(horizontalInput);
    }

    public void TakeDamage(float damage)
    {
        tankController.TakeDamage(damage);
    }

    public void SendCalculatedTime()
    {
        currentSurvivedTime += Time.deltaTime;

        if(currentSurvivedTime >= timeDurationToUpdateSurvivedTime)
        {
            AchievementService.Instance.OnCretainTimeSurvived((int)timeDurationToUpdateSurvivedTime);
            currentSurvivedTime = 0;
        }
    }
}
