using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public KeyCode Interact;
    public float InteractRange;

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(Interact))
        {
            Debug.Log(Interact);
            Collider2D check = Physics2D.OverlapCircle(transform.position, InteractRange, 9);
            if(check/* && check.CompareTag("Mission")*/)
            {
                Debug.Log(check);
            }
            
            
            
        }
    }
}
