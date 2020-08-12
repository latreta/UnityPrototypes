using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movementDir = Vector3.zero;
    private CharacterController _characterController;
    [SerializeField]
    private float movementSpeed = 10f;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
        {
            Debug.LogWarning("No character controller found.");
        }
    }
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        movementDir = new Vector3(xMov, 0, zMov);
    }

    private void FixedUpdate()
    {
        movementDir *= Time.fixedDeltaTime * movementSpeed;
        _characterController.Move(movementDir);
    }
}
