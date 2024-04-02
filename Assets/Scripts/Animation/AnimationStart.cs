using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStart : MonoBehaviour
{
    Animator animator;
    GameObject player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.name == transform.name)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= 6f)
                {
                    animator.enabled = true;
                    animator.SetBool("Open", !animator.GetBool("Open"));
                }
                    
            }
        }
    }
}
