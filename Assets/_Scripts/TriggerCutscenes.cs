using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TriggerCutscenes : MonoBehaviour
{
    public StarterAssets.FirstPersonController controller;
    public bool EnableObject;
    public bool DisableObject;
    public bool DestroyTrigger;
    public bool PlayAudio;
    private bool hasBeenTriggered;
    public GameObject TargetObj;

    public AudioSource AS;
    public AudioClip[] audioFiles;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<StarterAssets.FirstPersonController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Players" && !hasBeenTriggered)
        {
            if (PlayAudio == true)
            {
                AS.Play();
            }
            controller.MoveSpeed = 2.0f;

            if (EnableObject == true && AS.clip.length >= 5.0f)
            {
                TargetObj.SetActive(true);
            }
            else if (EnableObject == true)
            {
                TargetObj.SetActive(true);
            }

            if (DisableObject == false && AS.clip.length >= 5.0f)
            {
                TargetObj.SetActive(false);
            }
            else if (DisableObject == false)
            {
                TargetObj.SetActive(false);
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        controller.MoveSpeed = 4.0f;

        if (DestroyTrigger == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}
