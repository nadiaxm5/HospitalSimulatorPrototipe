using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    [SerializeField] float camMoveSpeed = 2.5f;
    [SerializeField] float camRotateSpeed = 1f;
    Vector3 rotateVector;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    float targetFOV;
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
        CameraMove();
        CameraRotate();
        CameraZoom();
    }

    private void CameraZoom()
    {
        targetFOV += -(Input.mouseScrollDelta.y * zoomSensitivity); //Zoom by mouse scroll
        targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV); //Limit zoom
        virtualCamera.m_Lens.FieldOfView = targetFOV;
    }

    private void CameraRotate() //Rotation with Q and E
    {
        rotateVector = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
        {
            rotateVector.y = camRotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotateVector.y = -(camRotateSpeed * Time.deltaTime);
        }

        transform.eulerAngles += rotateVector;
    }

    private void CameraMove() //Movement with WASD
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        moveVector = transform.right * moveVector.x + transform.forward * moveVector.z;

        transform.position += moveVector * Time.deltaTime * camMoveSpeed;
    }
}
