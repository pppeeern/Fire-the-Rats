using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float Duration;
    public Image fillCircle;

    private float holdTimer = 0;
    private bool isHold = false;

    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.E))
        {
            isHold = true;
            if(isHold)
            {
                holdTimer += Time.deltaTime;
                fillCircle.fillAmount = holdTimer / Duration;
                if(holdTimer >= Duration)
                {
                    Debug.Log("Mission Complete!!");
                }
            }
        }
        else if(UnityEngine.Input.GetKeyUp(KeyCode.E))
        {
            isHold = false;
            holdTimer = 0;
            fillCircle.fillAmount = 0;
        }
    }
}
