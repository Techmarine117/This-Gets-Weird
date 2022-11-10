using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject TargetObj;    

    private void OnTriggerStay(Collider other)
    {
        TargetObj.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        TargetObj.SetActive(true);
    }
}
