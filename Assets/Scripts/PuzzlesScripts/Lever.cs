using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
[SerializeField]  GameObject TargetObj;

    private void OnTriggerEnter(Collider other)
    {
        TargetObj.SetActive(false);
    }
}
