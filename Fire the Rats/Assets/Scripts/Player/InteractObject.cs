using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public KeyCode Interact;
    public LayerMask layerMask;
    public bool isInteract = false;
    private PlayerControl playerControl;
    private GrabItem grabItem;
    void Start()
    {
        playerControl = gameObject.GetComponent<PlayerControl>();
        grabItem = gameObject.GetComponent<GrabItem>();
    }

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(Interact))
        {
            Collider2D interactObj = Physics2D.OverlapCircle(transform.position, 1, layerMask);
            if(interactObj && interactObj.CompareTag("Mission"))
            {
                if(isInteract == false)
                {
                    isInteract = true;
                    Debug.Log($"Player {playerControl.PlayerIndex} is interact {interactObj.name}: {isInteract}");
                    interactObj.GetComponent<Mission>().Interact();
                }
                else
                {
                    isInteract = false;
                    playerControl.canMove = true;
                    Debug.Log($"Player {playerControl.PlayerIndex} is interact {interactObj.name}: {isInteract}");
                }
            }
        }
    }
}
