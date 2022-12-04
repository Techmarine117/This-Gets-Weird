using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformRotator : MonoBehaviour
{
    public float turnspeed = 50f;

    bool isTurning = false;

    public Switch sw;
    private void Update()
    {
        if (sw.isSwitchOn == true)
        {
            isTurning = true;
            transform.Rotate(0, turnspeed * Time.deltaTime, 0);
        }
        else if (sw.isSwitchOn == false)
        {
            isTurning = false;
            transform.Rotate(0, 0, 0);
        }

    }
}


