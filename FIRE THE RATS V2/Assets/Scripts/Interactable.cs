using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
    public UnityEvent interactExit;
    public GameObject player;
    private String interactKey;
    bool interacting;
    [SerializeField] private GameObject uiContainer;
    
    [Header ("Highlight")]
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material highlight;

    void Update()
    {
        if (isInRange)
        {
            GetComponentInParent<SpriteRenderer>().material = highlight;
            if(player.GetComponent<PlayerControl>().PlayerIndex == 1)
            {
                interactKey = "1Interact";
            }
            else if(player.GetComponent<PlayerControl>().PlayerIndex == 2)
            {
                interactKey = "2Interact";
            }
            if(Input.GetButtonDown(interactKey))
            {
                if(!interacting)
                {
                    interacting = true;
                    UIDisable();
                    interactAction.Invoke();
                }
                else
                {
                    interacting = false;
                    interactExit.Invoke();
                }
            }
            else
            {
                if(!interacting)
                {
                    UIEnable();
                }
            }
        }
        else
        {
            GetComponentInParent<SpriteRenderer>().material = defaultMat;
            interactExit.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        if(player.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log($"{player.name} in {transform.parent.name} range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.gameObject;
        if (player.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log($"{player.name} out of {transform.parent.name} range");
        }
        player = null;
    }

    public void UIEnable()
    {
        uiContainer.SetActive(true);
    }
    public void UIDisable()
    {
        uiContainer.SetActive(false);
    }
}