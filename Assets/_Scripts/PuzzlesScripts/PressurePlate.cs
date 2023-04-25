using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    
    //public float deactivateDelay = 1f;
    //public Animator platAnim;

    public AudioSource audioOn;
    public AudioSource audioOff;
    //public AudioClip PressurePlateClip;


    private void Start()
    {
        //audio = GetComponent<AudioSource>();
    }


    public bool isCubeOnPlate;

    public bool isPlateActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("FPSPlayer") || GameObject.FindWithTag("pickUp"))
        {
            isPlateActive = true;
            audioOn.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isPlateActive = false;
        audioOff.Play();
    }

    //IEnumerator Delay()
    //{
    //    //yield return new WaitForSeconds(deactivateDelay);
    //    //TargetObj.SetActive(false);
    //    //audio.Stop();
    //    //platAnim.SetTrigger("Lower");
    //}
}
