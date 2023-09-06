using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementController_VS : MonoBehaviour
{
    [SerializeField]
    Joystick joystickController;
    [SerializeField]
    float tankMoveSpeed = 10;

    //To convert 2d Input in 3D.
    Vector3 inputDirection = Vector3.zero;

    private void Update()
    {
        MoveTank();
    }

    void MoveTank()
    {
        //inputDirection.x = joystickController.Direction.x;
        //inputDirection.y = 0;
        //inputDirection.z = joystickController.Direction.y;

        //inputDirection = transform.InverseTransformDirection(inputDirection);

        inputDirection = ((transform.right * joystickController.Direction.x) + (transform.forward * joystickController.Direction.y));
        transform.position += (tankMoveSpeed * Time.deltaTime * inputDirection);
    }
}
