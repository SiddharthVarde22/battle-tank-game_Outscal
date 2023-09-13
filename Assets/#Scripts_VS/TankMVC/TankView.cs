using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankController tankController;

    float horizontalInput, verticalInput;

    [SerializeField]
    Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Tank view Start");
    }

    // Update is called once per frame
    void Update()
    {
        TakeUserInput();
        TakeFireInput();

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            TakeDamage(50);
        }
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    void TakeUserInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput != 0)
        {
            CallPlayerRotate();
        }

        if(verticalInput != 0)
        {
            CallPlayerMove();
        }
    }

    void TakeFireInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            OnShootPressed();
        }
    }

    void OnShootPressed()
    {
        tankController.PlayerTankShoot(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    void CallPlayerMove()
    {
        tankController.PlayerMove(verticalInput);
    }

    void CallPlayerRotate()
    {
        tankController.PlayerRotate(horizontalInput);
    }

    public void TakeDamage(float damage)
    {
        tankController.TakeDamage(damage);
    }
}
