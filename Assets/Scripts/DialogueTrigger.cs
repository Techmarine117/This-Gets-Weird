using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //Savable
    private bool hasBeenTriggered;
    [SerializeField]
    private Dialogue dialogueSC;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Players" && !hasBeenTriggered)
        {
            Debug.Log("Triggered");
            dialogueSC.AS.clip = dialogueSC.audioFiles[0];
            dialogueSC.AS.Play();
            hasBeenTriggered = true;
        }
    }
}
