using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldMission : MonoBehaviour
{
    [SerializeField] private KeyCode holdKey;
    [SerializeField] private float holdDuration;
    [SerializeField] private Image progressBar;
    private float holdTimer;
    private bool isHold;
    private bool isTrigger;

    void Update()
    {
        isTrigger = gameObject.GetComponent<MissionController>().isTrigger;
        if (isTrigger)
        {
            if (Input.GetKeyDown(holdKey))
            {
                isHold = true;
            }
            else if (Input.GetKeyUp(holdKey))
            {
                isHold = false;
            }

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
        }
    }
}
