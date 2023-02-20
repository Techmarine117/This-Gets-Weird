using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public Animator switchAnim;

    public bool isSwitchOn = false;

    
    public void SwitchControl()
    {
        if (!isSwitchOn)
        {
            StartCoroutine(SwitchOn());
        }
        else StartCoroutine(SwitchOff());
    }

    public IEnumerator SwitchOff()
    {
        switchAnim.SetTrigger("Off");
        yield return new WaitForSeconds(0.35f);
        isSwitchOn = false;

    }
    public IEnumerator SwitchOn()
    {
        switchAnim.SetTrigger("On");
        yield return new WaitForSeconds(0.35f);
        isSwitchOn = true;
    }
}
