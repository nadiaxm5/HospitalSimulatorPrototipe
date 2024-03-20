using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 currentVelocity = Vector3.zero;
    [SerializeField] private Transform target;
    [SerializeField] float smoothTime = 0.25f;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        //Called after all Update functions, because tracks objects that might have moved inside Update
        Vector3 targetPosition = target.position + offset;

        //SmoothDamp gradually changes a vector towards a desired goal over time
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}
