using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed of the player
    public float moveSpeed = 5f;

    // Mouse sensitivity for looking around
    public float mouseSensitivity = 100f;

    // Camera to use for looking around
    public Camera playerCamera;

    // Vertical rotation angle limit
    public float verticalAngleLimit = 90.0f;

    private float _xRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the movement input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.y = 0f; // don't move up/down

        // Move the player
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        // Get the mouse input axes
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -verticalAngleLimit, verticalAngleLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}