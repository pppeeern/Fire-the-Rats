using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTwoSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject objectToShow;

    void Start()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(false); // Ensure the object is initially hidden
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(true); // Show the object when it's selected
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(false); // Hide the object when it's deselected
        }
    }
}
