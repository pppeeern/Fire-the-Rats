using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    public bool isTrigger = false;
    private Interactable field;
    private GameObject player;

    void Start()
    {
        field = GetComponentInChildren<Interactable>();
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

    //--Mission--//
    public enum Missions 
        {
        None,
        MoveBroken,
        FixWire,
        ChangeBulb
        }
    public Missions missionsType;

    void Mission()
    {
        if(missionsType == Missions.MoveBroken)
        {
            Debug.Log("Move Broken");
        }
    }
}
