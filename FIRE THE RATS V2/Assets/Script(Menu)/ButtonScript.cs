using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject objectToShow;
    public LevelScript secondButtonScript;
    public Button btnOne;

    void Start() { 
        secondButtonScript = GetComponent<LevelScript>();
    }

    public void selectFirstBtn() { 
        btnOne.Select();
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
