using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StupidTrigger : MonoBehaviour
{
    public FirstPersonLook FPLook;
    public SpeedController SCon;

    [SerializeField] GameObject stuTrig;

    private void Start()
    {
        StartCoroutine(Activate());
    }
    IEnumerator Activate()
    {
        yield return new WaitForSeconds(4f);
        FPLook.EnableLook();
        SCon.ResumeSpeed();
        stuTrig.SetActive(false);
    }
}
