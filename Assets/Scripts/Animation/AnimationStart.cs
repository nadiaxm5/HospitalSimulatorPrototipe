using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationStart : MonoBehaviour
{
    Animator animator;
    GameObject player;
    [SerializeField] private AudioClip openDoorSound;
    private float distance;
    private bool isGoingToOpen;
    private Navigation_NavMesh playerNavMesh;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerNavMesh = player.GetComponent<Navigation_NavMesh>();
        isGoingToOpen = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isGoingToOpen = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.name == transform.name)
            {
                isGoingToOpen = true;
                playerNavMesh.SetDestination(transform.position);
            }
        }

        if (isGoingToOpen)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 6f)
            {
                animator.enabled = true;
                animator.SetBool("Open", !animator.GetBool("Open"));
                SoundFXManager.instance.PlaySoundFXClip(openDoorSound, transform, 1f);
                isGoingToOpen = false;
                Vector3 playerPosition = new Vector3(playerNavMesh.transform.position.x, playerNavMesh.transform.position.y, playerNavMesh.transform.position.z - 0.3f);
                playerNavMesh.SetDestination(playerPosition);
                Debug.Log(playerPosition);
            }
        }
        //new Vector3(-2.7f, 0.954f, 38.9f)
    }
}
