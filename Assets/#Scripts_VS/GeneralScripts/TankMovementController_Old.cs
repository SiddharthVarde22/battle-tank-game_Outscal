
using UnityEngine;

public class TankMovementController_Old : MonoBehaviour
{
    [SerializeField]
    private Joystick joystickController;
    [SerializeField]
    private float tankMoveSpeed = 10;

    //To convert 2d Input in 3D.
    private Vector3 inputDirection = Vector3.zero;

    private void Update()
    {
        MoveTank();
    }

    private void MoveTank()
    {
        //inputDirection.x = joystickController.Direction.x;
        //inputDirection.y = 0;
        //inputDirection.z = joystickController.Direction.y;

        //inputDirection = transform.InverseTransformDirection(inputDirection);

        inputDirection = ((transform.right * joystickController.Direction.x) + (transform.forward * joystickController.Direction.y));
        transform.position += (tankMoveSpeed * Time.deltaTime * inputDirection);
    }
}
