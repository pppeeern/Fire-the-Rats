using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerOneSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject objectToShow;
    public bool selectPlayerOne = true;

    public void OnButtonPress()
    {
        selectPlayerOne = false;
    }

    void Start()
    {
        if (objectToShow != null && selectPlayerOne == true)
        {
            objectToShow.SetActive(false); // Ensure the object is initially hidden
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (objectToShow != null && selectPlayerOne == true)
        {
            objectToShow.SetActive(true); // Show the object when it's selected
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (objectToShow != null && selectPlayerOne == true)
        {
            objectToShow.SetActive(false); // Hide the object when it's deselected
        }
    }
}
