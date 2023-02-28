using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Transform placeholder;
    //public GameObject puzzleCube;
    bool hasCube = false;
    public void CubeControl()
    {
        if(!hasCube)
        {
            PickedUP();
        }
        else { NotPickedUp();}
    }

    public void PickedUP()
    {
        //hasCube = true;
        this.transform.rotation = transform.rotation;
        this.transform.position = placeholder.position;
    }

    void NotPickedUp()
    {
        hasCube = false;
        //this.transform.position = null;
    }
}
