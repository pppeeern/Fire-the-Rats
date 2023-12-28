using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public bool isTrigger = false;

    public void MissionTrigger()
    {
        if(!isTrigger)
        {
            isTrigger = true;
            Debug.Log("Mission Trigger");
        }
    }

    public void MissionExit()
    {
        if(isTrigger)
        {
            isTrigger = false;
            Debug.Log("Mission Exit");
        }
    }
}
