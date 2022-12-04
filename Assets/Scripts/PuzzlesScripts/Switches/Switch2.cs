using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SW2
{
    public class Switch2 : MonoBehaviour
    {
        public Animator switchAnim;

        public bool isSwitchOn = false;

        public float castLength;
        public float turnspeed = 50f;

        public GameObject gameCam;
        public GameObject plat;


        bool isTurning = false;

        private void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(gameCam.transform.position, gameCam.transform.forward, out hit, castLength))
            {
                if (hit.collider.tag == "Switch2")
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

            if (isSwitchOn == true)
            {
                isTurning = true;
                plat.transform.Rotate(0, turnspeed * Time.deltaTime, 0);
            }
            else if (isSwitchOn == false)
            {
                isTurning = false;
                plat.transform.Rotate(0, 0, 0);
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
}

