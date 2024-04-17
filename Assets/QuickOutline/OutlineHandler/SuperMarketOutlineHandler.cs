using System.Collections;
using UnityEngine;

public class SuperMarketOutlineHandler : MonoBehaviour
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

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        EnableOutline(Physics.Raycast(ray, out hit) && hit.transform == transform);
    }
}