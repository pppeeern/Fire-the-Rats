using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HoldMission : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private float holdDuration;
    private KeyCode holdKey;
    private float holdTimer;
    private bool isHold;
    private bool isTrigger;

    private Interactable field;
    private GameObject player;

    public UnityEvent nextAction;

    void Start()
    {
        field = GetComponentInChildren<Interactable>();
    }

    void Update()
    {
        isTrigger = gameObject.GetComponent<MissionSettings>().isTrigger;
        if (isTrigger)
        {
            progressBar.gameObject.SetActive(true);
            //Get Player
            player = field.player;
            if(player.GetComponent<PlayerControl>().PlayerIndex == 1)
            {
                holdKey = KeyCode.LeftControl;
            }
            else if(player.GetComponent<PlayerControl>().PlayerIndex == 2)
            {
                holdKey = KeyCode.Keypad0;
            }

            //Get Input
            if (Input.GetKeyDown(holdKey))
            {
                isHold = true;
            }
            else if (Input.GetKeyUp(holdKey))
            {
                isHold = false;
            }

            //
            if (isHold)
            {
                holdTimer += Time.deltaTime;
                progressBar.fillAmount = holdTimer / holdDuration;
            }
            else
            {
                holdTimer = 0;
                progressBar.fillAmount = 0;
            }
            if(holdTimer >= holdDuration)
            {
                nextAction.Invoke();
            }
        }
        else
        {
            holdTimer = 0;
            progressBar.fillAmount = 0;
            progressBar.gameObject.SetActive(false);
        }
    }
}
