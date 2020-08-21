using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movementDir = Vector3.zero;
    private IMotor _motor;
    private bool isJumpPressed = false;

    void Start()
    {
        _motor = GetComponent<IMotor>();
        
        if (_motor == null)
        {
            Debug.LogWarning("No Player Moto was found.");
        }
    }
    void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");
        isJumpPressed = Input.GetButtonDown("Jump");

        movementDir = new Vector3(xMov, 0, zMov);
        _motor?.Move(movementDir, isJumpPressed);
    }
}
