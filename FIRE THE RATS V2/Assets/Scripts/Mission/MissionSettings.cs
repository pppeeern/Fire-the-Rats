using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionSettings : MonoBehaviour
{
 //   [SerializeField] private GameObject original;
    public enum Missions 
        {
        None,
        FixXPlug,
        FixTVCable,
        BulbSplinter,
        MessStove,
        FixLampWire,
        FixAirCon,
        FixAirCom,
        }
    public Missions missionsType;
    //
    public bool isTrigger = false;
    private Interactable field;
    private GameObject player;
    private GameController controller;
    private GameObject label;

    public bool finish;
    public string detail;
    GameObject[] missionLists;

    void Start()
    {
        field = GetComponentInChildren<Interactable>();
        controller = GameObject.Find("Settings").GetComponent<GameController>();
        label = GameObject.Find("LabelContainer");
        missionLists = controller.missionLists;
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
        finish = true;
        field.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().material = defaultMat;
        controller.completedMission++;
        Debug.Log(controller.completedMission);
        //original.GetComponent<MissionSettings>().finish = true; finish = true;
    }

    //--Mission--//
    void Mission()
    {
        if(missionsType == Missions.FixXPlug)
        {
            GameObject.Find("ExtensionPlug_0").SetActive(false);
        }
        else if (missionsType == Missions.FixTVCable)
        {
            GameObject.Find("TV_Cable_0").SetActive(false);
        }
        else if (missionsType == Missions.BulbSplinter)
        {
            gameObject.SetActive(false);
            MissionFinish();
        }
        else if(missionsType == Missions.MessStove)
        {
            GameObject.Find("Stove_0").SetActive(false);
        }
        else if (missionsType == Missions.FixLampWire)
        {
            GameObject.Find("Lamp_Wire_0").SetActive(false);
        }
    }
}
