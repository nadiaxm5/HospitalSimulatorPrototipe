using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    RaycastManager raycastManager;
    public Texture2D cursorNormal;
    public Texture2D cursorHover;

    private void Awake()
    {
        raycastManager = GameObject.FindObjectOfType<RaycastManager>();
        ChangeCursor(cursorNormal);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = raycastManager.GetHit();

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Clickable"))
            {
                ChangeCursor(cursorHover);
            }
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
    }
}
