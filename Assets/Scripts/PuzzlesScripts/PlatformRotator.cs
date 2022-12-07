using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformRotator : MonoBehaviour
{
    [SerializeField] float turnspeed = 30f;

    public SwitchManager switchScript;

    private void Update()
    {
        if (switchScript.isSwitchOn == true)
        {
            transform.Rotate(0, turnspeed * Time.deltaTime, 0);
        }
        else if (switchScript.isSwitchOn == false)
        {
            transform.Rotate(0, 0, 0);
        }
    }

}


