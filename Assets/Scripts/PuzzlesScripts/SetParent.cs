using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    public GameObject puzzleBox;
    public GameObject parentPlat;

    Transform tempTrans;
    private void OnCollisionEnter(Collision collision)
    {
        tempTrans = puzzleBox.transform.parent;
        puzzleBox.transform.parent = parentPlat.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        puzzleBox.transform.parent = tempTrans;
    }


}
