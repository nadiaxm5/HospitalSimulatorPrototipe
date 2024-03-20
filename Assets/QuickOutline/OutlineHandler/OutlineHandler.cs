using System.Collections;
using UnityEngine;

public class OutlineHandler : MonoBehaviour
{

    private Outline outline;

    private void Awake()
    {
        //fetch component, set values
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void EnableOutline(bool b)
    {
        outline.enabled = b;
    }

    private void OnMouseEnter()
    {
        EnableOutline(true);
    }

    private void OnMouseExit()
    {
        EnableOutline(false);
    }
}