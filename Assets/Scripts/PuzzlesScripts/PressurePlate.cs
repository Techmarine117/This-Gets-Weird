using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject TargetObj;    

    private void OnTriggerStay(Collider other)
    {
        TargetObj.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        TargetObj.SetActive(true);
    }
}
