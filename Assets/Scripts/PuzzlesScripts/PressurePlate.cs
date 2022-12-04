using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    //public GameObject TargetObj;
    public GameObject obj;
    public float deactivateDelay = 1f;
    public Animator platAnim;
    public float speed = 30f;

    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        //TargetObj.SetActive(true);
        platAnim.SetTrigger("Rise");
    }
    private void OnTriggerExit(Collider other)
    {        
        StartCoroutine(Delay());
        audio.Play();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(deactivateDelay);
        //TargetObj.SetActive(false);
        audio.Stop();
        platAnim.SetTrigger("Lower");
    }
}
