using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 hitPoint;
    RaycastHit hit;

    private void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
    }

    public RaycastHit GetHit()
    {
        return hit;
    }
}
