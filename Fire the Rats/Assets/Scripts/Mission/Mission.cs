using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public enum Missions {FixWire, ChangeBulb}
    public Missions Type;
    private GameObject player;

    //private ProgressBar progress;

    public void Interact()
    {
        Debug.Log("Do mission!");
        

        /*Collider2D interacted = Physics2D.OverlapCircle(transform.position, 1);
        if(interacted.CompareTag("Player"))
        {
            player = interacted.gameObject;
            if(player.GetComponent<GrabItem>().itemHold != null)
            {
                Debug.Log($"Mission is {Type}");
                switch(Type)
                {
                    case Missions.FixWire:
                        FixWire();
                        break;
                    case Missions.ChangeBulb:
                        Debug.Log("Changing bulb");
                        ChangeBulb();
                        break;
                    default:
                        Debug.Log("Not yet");
                        break;
                }
            }
            else
            {
                player.GetComponent<InteractObject>().isInteract = false;
            }
        }*/
    }

    /*public float Duration;
    public Image fillCircle;

    private float holdTimer = 0;
    private bool isHold = false;
    private void FixWire()
    {
        if (player.GetComponent<GrabItem>().itemHold.name == "Gem")
        {
            player.GetComponent<PlayerControl>().canMove = false;
            Debug.Log("Fixing Wire");
            if (UnityEngine.Input.GetKey(KeyCode.E) && isHold == false)
            {
                isHold = true;
                holdTimer += Time.deltaTime;
                fillCircle.fillAmount = holdTimer / Duration;
                if(holdTimer >= Duration)
                {
                    Debug.Log("Mission Complete!!");
                    holdTimer = 0;
                }
            }
            else if(UnityEngine.Input.GetKeyUp(KeyCode.E))
            {
                isHold = false;
                holdTimer = 0;
                fillCircle.fillAmount = 0;
            }
            if(isHold)
            {
                holdTimer += Time.deltaTime;
                fillCircle.fillAmount = holdTimer / Duration;
                if(holdTimer >= Duration)
                {
                    Debug.Log("Mission Complete!!");
                    holdTimer = 0;
                }
            }
        }
        else{Debug.Log("Wrong tool!");}
    }
    private void ChangeBulb()
    {
        if (player.GetComponent<GrabItem>().itemHold.name == "Ball")
            {
                player.GetComponent<PlayerControl>().canMove = false;
                Debug.Log("Changing bulb");
            }
        else{Debug.Log("Wrong tool!");}
    }*/
}
