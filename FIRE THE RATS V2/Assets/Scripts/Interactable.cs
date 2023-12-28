using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public UnityEvent interactExit;
        
    bool interacting;

    void Update()
    {
        if (isInRange)
        {
            UIEnable();
            if(Input.GetKeyDown(interactKey))
            {
                if(!interacting)
                {
                    interacting = true;
                    interactAction.Invoke();
                }
                else
                {
                    interacting = false;
                    interactExit.Invoke();
                }
            }
        }
        else
        {
            interactExit.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player out of range");
        }
    }

    [SerializeField] private GameObject container;

    public void UIEnable()
    {
        container.SetActive(true);
    }
    public void UIDisable()
    {
        container.SetActive(false);
    }
}