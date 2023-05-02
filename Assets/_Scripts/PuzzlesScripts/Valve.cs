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
        public ParticleSystem waterParticles2;

        AudioSource waterSound;


        private void Start()
        {
            waterSound = GetComponent<AudioSource>();
        }
        public void ValveControl()
        {
            if (!isRaised)
            {
                StartCoroutine(WaterRaised());
            }
            else { StartCoroutine(WaterLowered()); }
        }

        IEnumerator WaterRaised()
        {
            valveAnim.SetTrigger("On");
            waterAnim.ResetTrigger("Lower");
            waterAnim.SetTrigger("Raise");
            waterParticles2.Play();
            waterSound.Play();
            yield return new WaitForSeconds(5f);
            waterParticles2.Stop();
            isRaised = true;


        }

        IEnumerator WaterLowered()
        {
            valveAnim.SetTrigger("Off");
            waterAnim.ResetTrigger("Raise");
            waterAnim.SetTrigger("Lower");
            waterParticles.Play();
            waterSound.Play();
            yield return new WaitForSeconds(5f);
            waterParticles.Stop();
            isRaised = false;


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

