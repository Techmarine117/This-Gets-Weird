using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    float tempSpeed;
    public FirstPersonMovement FPSmvmt;
    public void StopSpeed()
    {
        tempSpeed = FPSmvmt.speed;
        FPSmvmt.speed = 0;
    }

    public void ResumeSpeed()
    {
        FPSmvmt.speed = tempSpeed;
    }

    public void CanRun()
    {
        FPSmvmt.canRun = true;
    }

    public void SpeedChangeAfterIntro()
    {
        FPSmvmt.speed = FPSmvmt.speedAfterIntro;
    }
}
