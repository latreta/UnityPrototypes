using System;
using UnityEngine;

public class PlayerMotor : MonoBehaviour, IMotor
{
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float gravity = 20f;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogWarning("Character controller not found.");
        }
    }

    public void Move(Vector3 direction, bool isJumpPressed)
    {
        if (controller.isGrounded) {
            moveDirection = transform.TransformDirection(direction);
            moveDirection *= speed;
            if (isJumpPressed)
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
