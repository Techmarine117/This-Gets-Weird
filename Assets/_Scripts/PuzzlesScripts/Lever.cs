using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject TargetObj;

    private void OnTriggerEnter(Collider other)
    {
        TargetObj.SetActive(false);
    }
}
