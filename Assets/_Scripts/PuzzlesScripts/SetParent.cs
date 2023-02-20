using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    //public Transform parent;
    public GameObject child;
    bool isOnPlatform;

    private void OnCollisionEnter(Collision collision)
    {
        //child.transform.SetParent(parent);
        isOnPlatform = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //child.transform.SetParent(null);
        isOnPlatform = false;
    }

    private void Update()
    {
        if(isOnPlatform)
        {
            child.transform.SetParent(this.transform);
        }
        else
        {
            child.transform.SetParent(null);
        }
    }
}
