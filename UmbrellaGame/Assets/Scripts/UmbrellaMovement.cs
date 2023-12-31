using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaMovement : MonoBehaviour
{
    [SerializeField] float openedSpeed = 1f;
    [SerializeField] float sidewaysMovSpeed = 2f;
    [SerializeField] UmbrellaSpriteController umbrellaSpriteController;
    [SerializeField] GameResetter gameResetter;
    //private Rigidbody2D rigidbody;
    public bool opened = true;
    private bool movingLeft = false;
    private bool movingRight = false;
    public bool canMove = true;

    // Movement Clamp logic
    [SerializeField] float openedMovementClamp = 1.9f;
    [SerializeField] float closedMovementClamp = 2.6f;
    private float maxPos;
    [SerializeField] private float joystickMoveSpeed = 2f;
    [SerializeField] private Joystick joystick;
    public int controlId = 0;



    // Accelerometer variables
    float dirX;
    [SerializeField] float gyroMoveSpeed = 5f;

    private void OnEnable()
    {
        gameResetter.OnGameReset += ResetMovement;
        maxPos = openedMovementClamp;
    }

    private void OnDisable()
    {
        gameResetter.OnGameReset -= ResetMovement;
    }
    private void ResetMovement()
    {
        opened = true;
        movingLeft = false;
        movingRight = false;
        canMove = true;
    }

    public void ChangeClampValues(bool isOpened)
    {
        if (isOpened)
        {
            maxPos = openedMovementClamp;
        }
        else
        {
            maxPos = closedMovementClamp;
        }
    }

    void Update()
    {
        if (canMove)
        {
            //Sideways movement

            // Joystick contoller
            if (controlId == 1)
            {
                float direction = joystick.Horizontal * joystickMoveSpeed * Time.deltaTime;
                if (joystick.Horizontal < 0)
                {
                    MoveLeft();
                }
                else if (joystick.Horizontal > 0)
                {
                    MoveRight();
                }
                else
                {
                    StopMovingSideways();
                }
                transform.Translate(Mathf.Clamp(direction, -maxPos, maxPos), 0, 0);
            }
            else if (controlId == 2)
            {
                // Buttons contoller
                if (movingLeft && !movingRight && transform.position.x > -maxPos)
                {
                    transform.Translate(-sidewaysMovSpeed * Time.deltaTime, 0, 0);
                }

                if (movingRight && !movingLeft && transform.position.x < maxPos)
                {
                    transform.Translate(sidewaysMovSpeed * Time.deltaTime, 0, 0);
                }
            }
            else if (controlId == 3)
            {
                //Gyroscope controller
                dirX = Input.acceleration.x * gyroMoveSpeed * Time.deltaTime;
                if (Input.acceleration.x < 0)
                {
                    MoveLeft();
                }
                else if (Input.acceleration.x > 0)
                {
                    MoveRight();
                }
                else
                {
                    StopMovingSideways();
                }
                transform.Translate(Mathf.Clamp(dirX, -maxPos, maxPos), 0, 0); // TODO: chose correct clamp values. Current values are random
            }
        }
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void MoveLeft()
    {
        if (!movingLeft)
        {
            movingLeft = true;
            movingRight = false;
            umbrellaSpriteController.RotateLeft();
        }  
        
    }

    public void MoveRight()
    {
        if (!movingRight)
        {
            movingRight = true;
            movingLeft = false;
            umbrellaSpriteController.RotateRight();
        }

    }

    public void StopMovingSideways()
    {
        if (movingLeft || movingRight)
        {
            movingLeft = false;
            movingRight = false;
            umbrellaSpriteController.RotateStraight();
        }
    }
}
