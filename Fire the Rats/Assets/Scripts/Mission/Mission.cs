using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public enum Missions {FixWire, ChangeBulb}
    public Missions Type;
    private GameObject player;

    public void Interact()
    {
        Collider2D interacted = Physics2D.OverlapCircle(transform.position, 1);
        if(interacted.CompareTag("Player"))
        {
            player = interacted.gameObject;
            if(player.GetComponent<GrabItem>().itemHold != null)
            {
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
        }
    }

    public float Duration;
    public Image FillCircle;

    private float holdTimer = 0;
    private bool isHold = false;

    private void Progress()
    {
        if(isHold)
        {
            holdTimer += Time.deltaTime;
            FillCircle.fillAmount = holdTimer / Duration;
            if(holdTimer >= Duration)
            {

            }
        }
    }

    private void FixWire()
    {
        if (player.GetComponent<GrabItem>().itemHold.name == "Gem")
            {
                player.GetComponent<PlayerControl>().canMove = false;
                Debug.Log("Fixing Wire");
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
    }
}
