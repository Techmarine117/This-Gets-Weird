using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public Animator switchAnim;

    public bool isSwitchOn = false;

    public float castLength = 5f;

    public GameObject gameCam;

    public GameObject switchCol;
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(gameCam.transform.position, gameCam.transform.forward, out hit, castLength))
        {
            if (hit.collider.gameObject == switchCol)
            {
                if (Input.GetKeyDown(KeyCode.E) && isSwitchOn == false)
                {
                    SwitchOn();
                }
                else if (Input.GetKeyDown(KeyCode.E) && isSwitchOn == true)
                {
                    SwitchOff();
                }
            }
        }

        
    }
    public void SwitchOn()
    {
        isSwitchOn = true;
        switchAnim.SetTrigger("On");
    }

    public void SwitchOff()
    {
        isSwitchOn = false;
        switchAnim.SetTrigger("Off");
    }


}
