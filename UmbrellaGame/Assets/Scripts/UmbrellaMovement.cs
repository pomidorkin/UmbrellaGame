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
            // Downward speed
            /*if (opened)
            {
                //gameObject.transform.position
                transform.Translate(0, -openedSpeed * Time.deltaTime, 0);
            }*/

            //Sideways movement
            // Buttons contoller
            if (movingLeft && !movingRight && transform.position.x > -maxPos)
            {
                transform.Translate(-sidewaysMovSpeed * Time.deltaTime, 0, 0);
            }

            if (movingRight && !movingLeft && transform.position.x < maxPos)
            {
                transform.Translate(sidewaysMovSpeed * Time.deltaTime, 0, 0);
            }

            //Gyroscope controller
            //dirX = Input.acceleration.x * gyroMoveSpeed;
            //transform.Translate(Mathf.Clamp(dirX * Time.deltaTime, -maxPos, maxPos), 0, 0); // TODO: chose correct clamp values. Current values are random
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
            umbrellaSpriteController.RotateLeft();
        }  
        
    }

    public void MoveRight()
    {
        if (!movingRight)
        {
            movingRight = true;
            umbrellaSpriteController.RotateRight();
        }

    }

    public void StopMovingSideways()
    {
        movingLeft = false;
        movingRight = false;
        umbrellaSpriteController.RotateStraight();
    }
}
