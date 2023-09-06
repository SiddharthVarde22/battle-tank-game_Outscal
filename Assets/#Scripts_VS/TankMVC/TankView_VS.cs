using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView_VS : MonoBehaviour
{
    public TankController_VS tankController;

    float horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Tank view Start");
    }

    // Update is called once per frame
    void Update()
    {
        TakeUserInput();
    }

    public void SetTankController(TankController_VS tankController)
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

    void CallPlayerMove()
    {
        tankController.PlayerMove(verticalInput);
    }

    void CallPlayerRotate()
    {
        tankController.PlayerRotate(horizontalInput);
    }
}
