using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

/// NOT USED IN THE PROJECT
/// This script moves, rotates and zooms the camera
/// NOT USED IN THE PROJECT

public class CameraController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    Vector2 moveInput = Vector2.zero;
    [SerializeField] float camMoveSpeed = 2.5f;
    [SerializeField] float camRotateSpeed = 1f;
    Vector3 rotateVector;
    float rotationAngle;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    float targetFOV;
    float zoomInput;
    [SerializeField] float minFOV = 35f;
    [SerializeField] float maxFOV = 90f;
    [SerializeField] float zoomSensitivity = 5f;

    private void Start()
    {
        targetFOV = virtualCamera.m_Lens.FieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        RotateCamera();
        ZoomCamera();
    }

    public void OnInputMoveCamera(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInputRotateCamera(InputAction.CallbackContext context)
    {
        rotationAngle = context.ReadValue<float>();
    }

    public void OnInputZoomCamera(InputAction.CallbackContext context)
    {
        zoomInput = context.ReadValue<float>();
    }

    private void ZoomCamera()
    {
        targetFOV += zoomInput * zoomSensitivity; //Zoom by mouse scroll
        targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV); //Limit zoom
        virtualCamera.m_Lens.FieldOfView = targetFOV;
    }

    private void RotateCamera() //Rotation with Q and E
    {
        rotateVector.y = -rotationAngle * camRotateSpeed * Time.deltaTime;
        transform.eulerAngles += rotateVector;
    }

    private void MoveCamera() //Movement with WASD
    {
        moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        transform.position += moveVector * Time.deltaTime * camMoveSpeed;
    }
}
