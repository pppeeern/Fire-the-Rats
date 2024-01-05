using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionSettings : MonoBehaviour
{
    public enum Missions 
        {
        None,
        MoveBroken,
        FixTVCable,
        ChangeBulb,
        MessStove
        }
    public Missions missionsType;
    //
    public bool isTrigger = false;
    private Interactable field;
    private GameObject player;
    private MissionController controller;
    private GameObject label;

    public int missionIndex;
    public string detail;
    GameObject[] missionLists;

    void Start()
    {
        field = GetComponentInChildren<Interactable>();
        controller = GameObject.Find("Settings").GetComponent<MissionController>();
        label = GameObject.Find("LabelContainer");
        missionLists = controller.missionLists;

        //Get Mission Index
        missionIndex = -1;
        for (int i = 0; i < missionLists.Length; i++)
        {
            if (missionLists[i].name == detail)
            {
                missionIndex = i+1; break;
            }
        }
    }

    void Update()
    {
        player = field.player;
    }

    public void MissionTrigger()
    {
        if(!isTrigger)
        {
            Debug.Log("Mission Trigger");
            isTrigger = true;
            player.GetComponent<PlayerControl>().CanMove = false;
            Mission();
        }
    }

    public void MissionExit()
    {
        if(isTrigger)
        {
            isTrigger = false;
            player.GetComponent<PlayerControl>().CanMove = true;
            Debug.Log("Mission Exit");
        }
    }

    [SerializeField] private Material defaultMat;
    public void MissionFinish()
    {
        MissionExit();
        field.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().material = defaultMat;
        controller.completedMission++;
        Debug.Log(controller.completedMission);
        //label.transform.Find("Label"+missionIndex).gameObject.SetActive(false);
    }

    //--Mission--//
    void Mission()
    {
        if(missionsType == Missions.FixTVCable)
        {
            GameObject.Find("TV_Cable_0").SetActive(false);
        }
        else if(missionsType == Missions.MessStove)
        {
            GameObject.Find("Stove_0").SetActive(false);
        }
    }
}
