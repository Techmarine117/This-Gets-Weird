using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve
{
    public class Valve : MonoBehaviour
    {
        bool isRaised = false;

        public Animator valveAnim;
        public Animator waterAnim;

        public ParticleSystem waterParticles;

        public void ValveControl()
        {
            if (!isRaised)
            {
                StartCoroutine(WaterRaised());
            }
            else { WaterLowered(); }
        }

        IEnumerator WaterRaised()
        {
            isRaised = true;
            valveAnim.SetTrigger("On");
            waterAnim.SetTrigger("Raise");
            waterParticles.Play();
            yield return new WaitForSeconds(5.5f);
            waterParticles.Stop();
        }

        void WaterLowered()
        {
            isRaised = false;
            valveAnim.SetTrigger("Off");
            waterAnim.SetTrigger("Lower");
        }

        //    public Animator valveAnim;
        //    public Animator waterAnim;

        //    public float castLength;

        //    public GameObject gameCam;

        //    bool isRaised = false;

        //    private void Update()
        //    {
        //        RaycastHit hit;

        //        if (Physics.Raycast(gameCam.transform.position, gameCam.transform.forward, out hit, castLength))
        //        {
        //            if (hit.collider.tag == "Valve")
        //            {
        //                if (Input.GetKeyDown(KeyCode.E) && isRaised == false)
        //                {
        //                    WaterRaise();
        //                }
        //                else if (Input.GetKeyDown(KeyCode.Q) && isRaised == true)
        //                {
        //                    WaterLower();
        //                }
        //            }
        //        }

        //    }
        //    public void WaterRaise()
        //    {
        //        isRaised = true;
        //        valveAnim.SetTrigger("Turn");
        //        waterAnim.SetTrigger("Raise");
        //    }

        //    public void WaterLower()
        //    {
        //        isRaised = false;
        //        valveAnim.SetTrigger("Turn");
        //        waterAnim.SetTrigger("Lower");
        //    }
        //}
    }
}

