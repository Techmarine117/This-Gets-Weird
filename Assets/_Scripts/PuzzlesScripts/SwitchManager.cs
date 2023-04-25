using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public Animator switchAnim;

    public bool isSwitchOn = false;

    [SerializeField] AudioSource lever;

    
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
        lever.Play();
        yield return new WaitForSeconds(0.35f);
        isSwitchOn = false;

    }
    public IEnumerator SwitchOn()
    {
        switchAnim.SetTrigger("On");
        lever.Play();
        yield return new WaitForSeconds(0.35f);
        isSwitchOn = true;
    }
}
