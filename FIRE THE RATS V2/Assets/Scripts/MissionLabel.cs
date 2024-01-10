using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionLabel : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    private GameController controller;
    private GameObject[] missionLists;
    private GameObject label;

    public void Start()
    {
        controller = settings.GetComponent<GameController>();
    }
    void Update()
    {
        if(controller.isRandom == true)
        {
            
            missionLists = controller.missionLists;
            for (int i = 0; i < missionLists.Length; i++)
            {
                Transform label = transform.GetChild(i);
                TMP_Text textComponent = label.GetComponent<TMP_Text>();
                if (missionLists[i].GetComponent<MissionSettings>().finish == false)
                {
                    textComponent.text = missionLists[i].GetComponent<MissionSettings>().detail;
                }
                else
                {
                    Debug.Log("MissionFinished");
                    GameObject labelobj = label.gameObject;
                    labelobj.SetActive(false);
                }
            }
        }
    }
}
