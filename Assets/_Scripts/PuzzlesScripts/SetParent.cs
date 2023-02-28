using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    public Transform parent;
    public GameObject child;

    private void OnCollisionEnter(Collision collision)
    {
        child.transform.SetParent(parent);
    }

    private void OnCollisionExit(Collision collision)
    {
        child.transform.SetParent(null);
    }
}
