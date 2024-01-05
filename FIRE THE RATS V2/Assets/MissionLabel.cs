using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionLabel : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    private MissionController missionController;
    private GameObject[] missionLists;
    private GameObject label;

    public void Start()
    {
        missionController = settings.GetComponent<MissionController>();
    }
    public void Update()
    {
        if(missionController.isRandom)
        {
            missionLists = missionController.missionLists;
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform label = transform.GetChild(i);
                //Debug.Log("Child name: " + label.name);
                TMP_Text textComponent = label.GetComponent<TMP_Text>();
                //Debug.Log(textComponent.text);
                textComponent.text = missionLists[i].name;
            }
        }
    }
}
