using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    }


}
